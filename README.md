# Log Project

## Packages

## Commands
dotnet sln add (ls -r **/*.csproj)

dotnet add reference ../Log.Domain/Log.Domain.csproj
dotnet add reference ../Log.Domain/Log.Domain.csproj

dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore


dotnet ef migrations add init
dotnet ef database update 

## Architectures
Log.API
Log.Application
Log.Contract
Log.Domain
Log.Infrastructure
Log.Infrastructure.MessageBus
Log.Infrastructure.Mongo
Log.Persistence