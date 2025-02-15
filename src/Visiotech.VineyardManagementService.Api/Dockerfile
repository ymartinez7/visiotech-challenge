FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Visiotech.VineyardManagementService.Api/Visiotech.VineyardManagementService.Api.csproj", "src/Visiotech.VineyardManagementService.Api/"]
RUN dotnet restore "./src/Visiotech.VineyardManagementService.Api/Visiotech.VineyardManagementService.Api.csproj"
COPY . .
WORKDIR "/src/src/Visiotech.VineyardManagementService.Api"
RUN dotnet build "./Visiotech.VineyardManagementService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Visiotech.VineyardManagementService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Visiotech.VineyardManagementService.Api.dll"]