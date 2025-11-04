# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["src/Web/Club.Web.csproj", "src/Web/"]
COPY ["src/Application/Club.Application.csproj", "src/Application/"]
COPY ["src/Cando/Cando.Application/Cando.Application.csproj", "src/Cando/Cando.Application/"]
COPY ["src/Cando/Cando.Domain/Cando.Domain.csproj", "src/Cando/Cando.Domain/"]
COPY ["src/Domain/Club.Domain.csproj", "src/Domain/"]
COPY ["src/Cando/Cando.Common/Cando.Common.csproj", "src/Cando/Cando.Common/"]
COPY ["src/Cando/Cando.Endpoint/Cando.Endpoint.csproj", "src/Cando/Cando.Endpoint/"]
COPY ["src/Cando/Cando.Infrastructure/Cando.Infrastructure.csproj", "src/Cando/Cando.Infrastructure/"]
COPY ["src/Infrastructure/Club.Infrastructure.csproj", "src/Infrastructure/"]
RUN dotnet restore "./src/Web/Club.Web.csproj"
COPY . .
WORKDIR "/src/src/Web"
RUN dotnet build "./Club.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Club.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Club.Web.dll"]