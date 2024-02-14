# Explainations of Pipeline-Templates

## backend-stage.yml

This template holds the full pipeline steps and uses the templates below to build up the full process.

---
## preparation.yml

This template sets up and prepares the pipeline environment for execution and deploying.

1. Downloading the artifact
2. Installing all the needed DEVDEER Bicep Modules
3. Creating a directory for and downloading the health-check script

---
## infrastructure.yml

This template handles the pipeline infrastructure using Bicep.

1. Deploying the Bicep from the `infrastructure` directory

---
## deployment.yml

This template keeps all steps needed to deploy the service.

1. Stopping the deploy slot
2. Deploying the on the deploy slot
3. Starting the deploy slot
4. Checking the slot health
5. Swapping the slot

---
## owasp.yml

This is a pipeline that runs on a weekly bases to check for known security issues.

---
# Usage

## Creating a new Pipeline in Azure DevOps
1. Go to `Pipelines` section in ADO.
2. Click `New Pipeline`.
3. Select `Use the classic editor` below all other options.
4. Leave it as it is and click on `Continue`.
5. Select `YAML` and click `Apply`.
6. For the name type in: `AssetsManager CI` or `AssetsManager CD`.
7. For `YAML file path` use `AssetsManager/.azuredevops/pipelines/ci.yml` or `AssetsManager/.azuredevops/pipelines/cd.yml`.
8. At the top click the dropdown of `Save & queue` and only select `Save`.
9. Now you find your pipeline in the `Pipelines` section and can manage and run them from there.
## CI
1. Copy old `azure-pipelines.yml` from `root` directory into `.azuredevops/pipelines`.
2. Rename it to `ci.yml` in the most cases.

## CD
1. In `.azuredevops/pipelines/cd.yml` put in the ProjectName into the `project` variable.
2. Set the `source` of the CI Pipeline to the same name as the pipeline itself in ADO.
3. Check the `branches` to match to correct production brach. In the most cases this is `dev`.
4. Check `deployBicep` for each stage.
5. Add sites if needed for amount of App Services.
6. Change the names of the `package` according to each App Service.

## Authorize Pipeline to set it's state in a PR using ADO Api
1. Go to ADO and under `Pipelines` go to `Library`.
2. Click on `Variable Group` and created a new one with the ProjectName.
3. Click `Add` to add a new variable.
4. Name it `PAT` and as the value but in a valid Personal Access Token for the organization. (Ideally create a new PAT for the pipeline beforehand.)