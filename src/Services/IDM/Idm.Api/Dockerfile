# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/IDM/Idm.Api/Idm.Api.csproj", "Services/IDM/Idm.Api/"]
COPY ["Services/IDM/Idm.Application/Idm.Application.csproj", "Services/IDM/Idm.Application/"]
COPY ["Services/IDM/Idm.Domain/Idm.Domain.csproj", "Services/IDM/Idm.Domain/"]
COPY ["BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
COPY ["Services/IDM/Idm.Infrastructure/Idm.Infrastructure.csproj", "Services/IDM/Idm.Infrastructure/"]
RUN dotnet restore "./Services/IDM/Idm.Api/Idm.Api.csproj"
COPY . .
WORKDIR "/src/Services/IDM/Idm.Api"
RUN dotnet build "./Idm.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Idm.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Idm.Api.dll"]