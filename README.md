# Pipelines

| Pipeline | Status                                                                                                                                                                                                                |
| -------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| CI       | [![Build Status](https://dev.azure.com/devdeer/AssetsManager/_apis/build/status%2FAssetsManager%20CI?branchName=dev)](https://dev.azure.com/devdeer/AssetsManager/_build/latest?definitionId=3&branchName=dev) |
| CD       | [![Build Status](https://dev.azure.com/devdeer/AssetsManager/_apis/build/status%2FAssetsManager%20CD?branchName=dev)](https://dev.azure.com/devdeer/AssetsManager/_build/latest?definitionId=2&branchName=dev) |

# Resources

## Design

No design resources available.

## Stages

| int                                                                                                                                                                                                                                | test                                                                                                                                                                                                                                 | prod                                                                                                                                                                                                                                 |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| [!["UI"](https://img.shields.io/endpoint?url=https%3A%2F%2Fdevdeer.blob.core.windows.net%2Fshared%2Fshields%2Fui-core-int.json)](https://ui-DD-AssetsManager-int.azurewebsites.net/)                           | [!["UI"](https://img.shields.io/endpoint?url=https%3A%2F%2Fdevdeer.blob.core.windows.net%2Fshared%2Fshields%2Fui-core-test.json)](https://ui-DD-AssetsManager-test.azurewebsites.net/)                           | [!["UI"](https://img.shields.io/endpoint?url=https%3A%2F%2Fdevdeer.blob.core.windows.net%2Fshared%2Fshields%2Fui-core-prod.json)](https://ui-DD-AssetsManager-prod.azurewebsites.net/)                           |
| [!["API"](https://img.shields.io/endpoint?label=Core&url=https%3A%2F%2Fdevdeer.blob.core.windows.net%2Fshared%2Fshields%2Fapi-core-int.json)](https://api-DD-AssetsManager-core-int.azurewebsites.net/swagger) | [!["API"](https://img.shields.io/endpoint?label=Core&url=https%3A%2F%2Fdevdeer.blob.core.windows.net%2Fshared%2Fshields%2Fapi-core-test.json)](https://api-DD-AssetsManager-core-test.azurewebsites.net/swagger) | [!["API"](https://img.shields.io/endpoint?label=Core&url=https%3A%2F%2Fdevdeer.blob.core.windows.net%2Fshared%2Fshields%2Fapi-core-prod.json)](https://api-DD-AssetsManager-core-prod.azurewebsites.net/swagger) |

# Introduction

# Local Development Docker Container

## Local MSSQL Server

Create the local mssql server container:

### Using docker

```shell
docker run -d --name mssql-dev \
  -e ACCEPT_EULA=Y \
  -e SA_PASSWORD=Sql-Server-Dev \
  -p 1433:1433 \
  --restart always \
  mcr.microsoft.com/mssql/server:2019-latest
```

### Using podman

```shell
podman run -d --name mssql-dev \
  -e ACCEPT_EULA=Y \
  -e SA_PASSWORD=Sql-Server-Dev \
  -p 1433:1433 \
  --restart always \
  mcr.microsoft.com/mssql/server:2019-latest
```

To create and migrate the database, navigate to the data entities project directory in a shell.
You need to have dotnet ef installed and execute the following command:

```shell
dotnet ef database update
```

## Local Redis

Create the local Redis container:

### Using docker

```shell
docker run --name redis-dev -p 6379:6379 --restart always -d redis
```

### Using podman

```shell
podman run --name redis-dev -p 6379:6379 --restart always -d redis
```

To connect to the container into the redis-cli, execute:

```shell
docker exec -it redis-dev redis-cli
```

## Local storage account

Create the local azurite container:

### Using docker

```shell
docker run --name storage-dev -p 10000:10000 -p 10001:10001 -p 10002:10002 --restart always -d mcr.microsoft.com/azure-storage/azurite
```

### Using podman

```shell
podman run --name storage-dev -p 10000:10000 -p 10001:10001 -p 10002:10002 -d mcr.microsoft.com/azure-storage/azurite
```

# Open firewalls to Cloud Databases

Create and delete firewall rules for the stage specific SQL-Server to access them using the devdeer.Azure Powershell Module:

```powershell
# Integration
New-AzdSqlFirewallRule -TenantId 18ca94d4-b294-485e-b973-27ef77addb3e -SubscriptionId c764670f-e928-42c2-86c1-e984e524018a -AzureSqlServerName sql-DD-AssetsManager-int
Clear-AzdAllSqlFirewallRules -TenantId 18ca94d4-b294-485e-b973-27ef77addb3e -SubscriptionId c764670f-e928-42c2-86c1-e984e524018a -AzureSqlServerName sql-DD-AssetsManager-int

# Test
New-AzdSqlFirewallRule -TenantId 18ca94d4-b294-485e-b973-27ef77addb3e -SubscriptionId c764670f-e928-42c2-86c1-e984e524018a -AzureSqlServerName sql-DD-AssetsManager-test
Clear-AzdAllSqlFirewallRules -TenantId 18ca94d4-b294-485e-b973-27ef77addb3e -SubscriptionId c764670f-e928-42c2-86c1-e984e524018a -AzureSqlServerName sql-DD-AssetsManager-test

# Production
New-AzdSqlFirewallRule -TenantId 18ca94d4-b294-485e-b973-27ef77addb3e -SubscriptionId c764670f-e928-42c2-86c1-e984e524018a -AzureSqlServerName sql-DD-AssetsManager-prod
Clear-AzdAllSqlFirewallRules -TenantId 18ca94d4-b294-485e-b973-27ef77addb3e -SubscriptionId c764670f-e928-42c2-86c1-e984e524018a -AzureSqlServerName sql-DD-AssetsManager-prod
```

# Clearing the database

```sql
-- select the database
USE [AssetsManager]
GO
-- prepare vars for iteration
DECLARE @sql NVARCHAR(500) = N''
DECLARE @getid CURSOR
-- create cursor on query
SET @getid = CURSOR FOR
    SELECT      CONCAT('ALTER TABLE ', CONCAT(s.NAME, CONCAT('.', CONCAT(t.NAME, CONCAT(' NOCHECK CONSTRAINT ALL;', CONCAT('DROP TABLE ', CONCAT(S.NAME, CONCAT('.', T.NAME)))))))) Command
    FROM        SYS.TABLES T
    INNER JOIN  SYS.SCHEMAS S
    ON          T.SCHEMA_ID = S.SCHEMA_ID
    WHERE       T.is_ms_shipped = 0 AND type_desc = 'USER_TABLE'
    UNION
    SELECT      CONCAT('DROP VIEW ', CONCAT(S.NAME, CONCAT('.', V.NAME))) Command
    FROM        SYS.VIEWS V
    INNER JOIN  SYS.SCHEMAS S
    ON          V.SCHEMA_ID = S.SCHEMA_ID
    WHERE       V.is_ms_shipped = 0
-- iterate over each row of the query
OPEN @getid
WHILE 1=1
BEGIN
    FETCH NEXT
    FROM @getid INTO @sql
    IF @@FETCH_STATUS < 0 BREAK -- last row
    -- execute the only field of the row as simply SQL
    EXECUTE sys.sp_executesql @sql;
END
-- deallocate resources
CLOSE @getid
DEALLOCATE @getid
GO
DBCC SHRINKDATABASE(N'AssetsManager')
GO
```
