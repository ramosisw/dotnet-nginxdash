FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY NginxDash/NginxDash.csproj NginxDash/
RUN dotnet restore NginxDash/NginxDash.csproj
COPY . .

WORKDIR /src/NginxDash
RUN dotnet build NginxDash.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NginxDash.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NginxDash.dll"]