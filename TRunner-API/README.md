# Migrations:

## Install dotnet-ef tool for the migration script

dotnet tool install --global dotnet-ef

## Add new migrations

dotnet ef migrations add {MigrationName} -p src/shared/TRunner.Infrastructure -s src/TRunner-API -c TRunner.Infrastructure.ConnectionStrings.TRunnerDbContext -v

## Remove new migrations

dotnet ef migrations remove -p src/shared/TRunner.Infrastructure -s src/TRunner-API -c TRunner.Infrastructure.ConnectionStrings.TRunnerDbContext -v

## Update database

dotnet ef database update -p src/shared/TRunner.Infrastructure -s src/TRunner-API -c TRunner.Infrastructure.ConnectionStrings.TRunnerDbContext -v
