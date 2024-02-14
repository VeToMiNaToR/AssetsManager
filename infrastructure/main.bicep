targetScope = 'subscription'

@description('The lower case name of the project as it appears in Azure DevOps.')
param projectName string

@description('The Azure region to deploy the resource to.')
param location string

@description('The name of the stage with the first letter in upper-case (e.g. \'Test\' or \'Production\').')
param stage string

@secure()
@description('Password for the SQL Server admin.')
param sqlPassword string

resource group 'Microsoft.Resources/resourceGroups@2021-01-01' = {
  name: 'rg-${toLower(projectName)}-${toLower(stage)}'
  location: location
}

module applyLock 'lock.bicep' = {
  scope: group
  name: 'applyLock'
}

module resources 'resources.bicep' = {
  scope: group
  name: 'resources'
  params: {
    location: location
    projectName: projectName
    stage: stage
    sqlPassword: sqlPassword
  }
}
