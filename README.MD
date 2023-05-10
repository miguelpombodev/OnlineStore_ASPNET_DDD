
# ASPNET CORE - Online Store

This is personal Online Store project, just for studying and practicing some .NET skills and DDD/TDD development.


## Badges

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)


## This project uses

- Entity Framework;
- Fluent Mapping; 
- JWT Authentication;
- Serilog;
- xUnit;


## Starting Locally
### Initiating Database
Firstly until now its necessary, build your own SQL Server Container
```bash
  docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<STRONG_PASSWORD>" -p 1433:1433 -d --name <CONTAINER_NAME> mcr.microsoft.com/mssql/server:2022-latest
```

And then, you can start it 
```bash
  docker start <CONTAINER_NAME>
```

To run the database script, check it out in this link below:

[Database Script 😄](https://github.com/miguelpombodev/Database-scripts/blob/main/Online_Store_Init_Script.sql)

### Cloning and starting the project
Clone the project with SSH
```bash
  git clone git@github.com:miguelpombodev/OnlineStore_ASPNET_DDD.git
```
or clone with HTTP

```bash
  git clone https://github.com/miguelpombodev/OnlineStore_ASPNET_DDD.git
```

Go to the directory

```bash
  cd OnlineStore_ASPNET_DDD
```

Build the project

```bash
  dotnet build
```

Run the project

```bash
  dotnet run ./OnlineStore.Web/OnlineStore.Web.csproj
```


## Licença

[MIT](https://choosealicense.com/licenses/mit/)

