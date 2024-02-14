# Infrastructure

## General

The deploy script can be used to deploy a stage in Azure. The stage will contain a default stage composition that consists of

- sql server
- sql database
- web server api
- web server ui
- dotnet core api app service
- node ui app service
- application insights

## How to setup

To setup this basic implementation, follow these steps:

1. Add your data to the `bicepSettings.json` file
2. add the `key vault reference` for the `sql password` in each staging `parameters file`

## Usage

1. Open a pwsh session
2. navigate into the infrastructure folder
3. Execute `./deploy.ps1 -Stage ${STAGE}`

Valid options for ${STAGE} are `int`, `test` and `prod`.