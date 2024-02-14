targetScope = 'resourceGroup'

@description('The lower case name of the project as it appears in Azure DevOps.')
param projectName string

@description('The Azure region to deploy the resource to.')
param location string

@description('The name of the stage with the first letter in upper-case (e.g. \'Test\' or \'Production\').')
param stage string

@secure()
@description('Password for the SQL Server admin.')
param sqlPassword string

var options = opt.outputs.options

module opt 'modules/options.bicep' = {
  name: 'options'
  params: {
    location: location
    projectName: projectName
    stageName: stage
  }
}

module appInsights 'modules/Microsoft.Insights/components.bicep' = {
  name: 'appInsights'
  params: {
    options: options
  }
}

module webServerCoreApi 'modules/Microsoft.Web/serverFarms.bicep' = {
  name: 'webServerCoreApi'
  params: {
    options: options
    skuSubTier: '1'
    skuTier: 'Standard'
    additionalName: 'core'
    osSystem: 'Windows'
  }
}

module webServerUi 'modules/Microsoft.Web/serverFarms.bicep' = {
  name: 'webServerUi'
  params: {
    options: options
    skuSubTier: '1'
    skuTier: 'Standard'
    osSystem: 'Linux' 
    additionalName: 'webui'
  }
}

module webAppUi 'modules/Microsoft.Web/sites.bicep' = {
  name: 'webAppUi' 
  params: {
    servicePlanSku: 'Standard'
    runtimeVersion: '18-lts'
    prefix: 'ui'
    options: options
    servicePlanName: webServerUi.outputs.name
    appInsightsKey: appInsights.outputs.instrumentationKey
    osSystem: 'Linux'
    environmentVariables: [
      {
        name: 'DEPLOY_SLOT'
        value: '0'
      }
    ]
    slotEnvironmentValues: [
      {
        name: 'DEPLOY_SLOT'
        value: '1'
      }
    ]
    additionalSlotSettings: [
      'DEPLOY_SLOT'
    ]
  }
}

module apiCore 'modules/Microsoft.Web/sites.bicep' = {
  name: 'apiCore'
  params: {
    servicePlanSku: 'Standard'
    runtimeVersion: 'v8.0'
    prefix: 'api'
    options: options
    additionalName: 'core'
    servicePlanName: webServerCoreApi.outputs.name
    appInsightsKey: appInsights.outputs.instrumentationKey
    osSystem: 'Windows'
    environmentVariables: [
      {
        name: 'DEPLOY_SLOT'
        value: '0'
      }
    ]
    slotEnvironmentValues: [
      {
        name: 'DEPLOY_SLOT'
        value: '1'
      }
    ]
    additionalSlotSettings: [
      'DEPLOY_SLOT'
    ]
  }
}

// URL ping test
module pingTest 'modules/Microsoft.Insights/webtest.bicep' = {
  name: 'pingTest'
  params: {
    options: options
    appInsightsId: appInsights.outputs.id
    appInsightsName: appInsights.outputs.name
    appServiceName: apiCore.outputs.name
    testUrl: 'https://${apiCore.outputs.name}.azurewebsites.net/health'
  }
}

module pingTestUi 'modules/Microsoft.Insights/webtest.bicep' = {
  name: 'pingTestUi'
  params : {
    options: options
    appInsightsId: appInsights.outputs.id
    appInsightsName: appInsights.outputs.name
    appServiceName: webAppUi.outputs.name
    testUrl: 'https://${webAppUi.outputs.name}.azurewebsites.net/api/health'
  }
}

module sqlServer 'modules/Microsoft.Sql/servers.bicep' = {
  name: 'sqlServer'
  params: {
    adminLogin: 'AssetsManager-admin'
    adminPassword: sqlPassword
    options: options
  }
}

module database 'modules/Microsoft.Sql/servers/databases.bicep' = {
  name: 'database'
  params: {
    databaseName: projectName
    options: options
    skuName: 'S0'
    skuTier: 'Standard'
    sqlServerName: sqlServer.outputs.name
  }
}
