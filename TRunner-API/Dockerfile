FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
COPY . .

ARG DEPLOYMENT_ENV MYSQL_USER MYSQL_DATABASE MYSQL_PASSWORD MINIO_ACCESS_KEY MINIO_SECRET_KEY MINIO_API_DOMAIN
WORKDIR /src/TRunner-API

RUN cp appsettings.$DEPLOYMENT_ENV.json appsettings.json
RUN sed -i "s/\$DEPLOYMENT_ENV/$DEPLOYMENT_ENV/g" appsettings.json
RUN sed -i "s/\$MYSQL_USER/$MYSQL_USER/g" appsettings.json
RUN sed -i "s/\$MYSQL_DATABASE/$MYSQL_DATABASE/g" appsettings.json
RUN sed -i "s/\$MYSQL_PASSWORD/$MYSQL_PASSWORD/g" appsettings.json
RUN sed -i "s/\$MINIO_ACCESS_KEY/$MINIO_ACCESS_KEY/g" appsettings.json
RUN sed -i "s/\$MINIO_SECRET_KEY/$MINIO_SECRET_KEY/g" appsettings.json
RUN sed -i "s/\$MINIO_API_DOMAIN/$MINIO_API_DOMAIN/g" appsettings.json

RUN dotnet build "TRunner-API.csproj" -c Release -o /build

FROM base as migrate
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

FROM base as build
RUN dotnet publish "TRunner-API.csproj" -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as api
EXPOSE 80

WORKDIR /app

COPY --from=build /publish .
ENTRYPOINT ["dotnet", "TRunner-API.dll"]