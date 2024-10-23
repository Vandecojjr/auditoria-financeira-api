FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY Auditoria.Financeira.Domain.Api/*.csproj ./Auditoria.Financeira.Domain.Api/
COPY Auditoria.Financeira.Domain/*.csproj ./Auditoria.Financeira.Domain/
COPY Auditoria.Financeira.Domain.Infra/*.csproj ./Auditoria.Financeira.Domain.Api/
COPY Auditoria.Financeira.Domain.Tests/*.csproj ./Auditoria.Financeira.Domain.Api/


RUN dotnet restore ./Auditoria.Financeira.Domain.Api/Auditoria.Financeira.Domain.Api.csproj

COPY . ./

RUN dotnet publish ./Auditoria.Financeira.Domain.Api/Auditoria.Financeira.Domain.Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /app/out ./

EXPOSE 80

ENTRYPOINT ["dotnet", "Auditoria.Financeira.Domain.Api.dll"]
