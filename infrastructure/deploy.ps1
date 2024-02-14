[CmdletBinding()]
param (	
	[Parameter(Mandatory = $true)]
	[ValidateSet("int", "test", "prod")]
	$Stage,
	[switch]
	$WhatIf
)

if ($PSScriptRoot.Contains(' ') -and $PSScriptRoot -ne $PWD) {
	throw "This script needs to be executed from inside its folder because white spaces where detected."
}
$root = $PSScriptRoot.Contains(' ') ? '.' : $PSScriptRoot

$tenantId = "18ca94d4-b294-485e-b973-27ef77addb3e"
$subscriptionId = "c764670f-e928-42c2-86c1-e984e524018a"
$stageParameterFile = "$root/parameters.$Stage.json"
$templateFile = "$root/main.bicep"

$parameterJson = Get-Content -Path $stageParameterFile -Raw | ConvertFrom-Json
if (!($parameterJson.parameters.location)) {
	throw "No location specified in '$stageParameterFile'."
}
$location = $parameterJson.parameters.location.value
$bicepContent = Get-Content -path $templateFile -Raw
if (!($bicepContent -match "targetScope = '(.*)'")) {
	throw "No targetScope defined in '$templateFile'."
}
$targetScope = $Matches[1]

# ensure that Devdeer.Azure modules is present
if ((Get-Module -all | Select-String -Raw Devdeer.Azure | Measure-Object).Count -eq 0) {
	Write-Host "Installing Devdeer.Azure Powershell..."
	Install-Module Devdeer.Azure -Force
	Import-Module Devdeer.Azure
	Write-Host "Done"
}
else {
	Write-Host "Module Devdeer.Azure Powershell was found."
}

# ensure that DEVDEER BICEP modules are installed
if (!(Test-Path ./modules)) {
	Write-Host "Installing DEVDEER bicep modules..."	
	Invoke-Expression -Command "& $root/install-modules.ps1"
}

# ensure AZ context
$currentContext = Get-AzContext
if ($currentContext.Subscription.Id -ne $subscriptionId -or $currentContext.Tenant.Id -ne $tenantId) {
	# current Az context is wrong
	Set-AzContext -Tenant $tenantId -Subscription $subscriptionId
}
else {
	# current Az context is fine
	Write-Host "Reusing subscription context for $subscriptionId."
}
if (!$?) {
	# something went wrong on of the commands before
	throw 'Could not set subscription scope. Maybe running Connect-AzAccount can fix the problem?'
}

$dateSuffix = Get-Date -Format "yyyy-dd-MM-HH-mm"
$deploymentName = "deploy-$dateSuffix"
if ($targetScope -eq "subscription") {
	# default deployment for subscription level
	Write-Host "Deploying at subscription level using template $deploymentPath ..."
	New-AzDeployment `
		-Name $deploymentName `
		-Location $location `
		-TemplateFile $templateFile `
		-TemplateParameterFile $stageParameterFile `
		-DeploymentDebugLogLevel All `
		-WhatIf:$WhatIf
}
elseif ($targetScope -eq "resourceGroup") {
	# unusual direct deployment to a pre-existing resource group
	if ($ResourceGroupName -eq "") {
		throw "No resource group name was specified."
	}
	if ($ResourceGroupLocation -eq "") {
		throw "No resource group location was specified."
	}
	$rg = Get-AzResourceGroup -Name $ResourceGroupName -Location $ResourceGroupLocation	
	if (!($rg)) {
		throw "$ResourceGroupName was not found."
	}
	Write-Host "Deploying at resource group level using template $deploymentPath ..."
	New-AzResourceGroupDeployment `
		-Name $deploymentName `
		-Location $location `
		-ResourceGroupName $rg.ResourceGroupName `
		-TemplateFile $templateFile `
		-TemplateParameterFile $stageParameterFile `
		-DeploymentDebugLogLevel All `
		-Mode Incremental `
		-WhatIf:$WhatIf
}
else {
	throw "Unsupported target scope $targetScope."
}
if ($stageParameterFile.Contains("temp")) {	
	Remove-Item $stageParameterFile -Force
}
