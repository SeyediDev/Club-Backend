# Base stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
ARG BUILD_CONTEXT=Club/Backend

# Copy project files
COPY ["src/CustomerPortal/Club.CustomerPortal.Api/Club.CustomerPortal.Api.csproj", "src/CustomerPortal/Club.CustomerPortal.Api/"]
COPY ["src/CustomerPortal/Club.CustomerPortal.Application/Club.CustomerPortal.Application.csproj", "src/CustomerPortal/Club.CustomerPortal.Application/"]
COPY ["src/Core/Club.Domain/Club.Domain.csproj", "src/Core/Club.Domain/"]
COPY ["src/Core/Club.Infrastructure/Club.Infrastructure.csproj", "src/Core/Club.Infrastructure/"]
COPY ["src/Core/Club.Application/Club.Application.csproj", "src/Core/Club.Application/"]
COPY ["../../Neo/src/Neo.Domain/Neo.Domain.csproj", "../../Neo/src/Neo.Domain/"]
COPY ["../../Neo/src/Neo.Application/Neo.Application.csproj", "../../Neo/src/Neo.Application/"]
COPY ["../../Neo/src/Neo.Infrastructure/Neo.Infrastructure.csproj", "../../Neo/src/Neo.Infrastructure/"]
COPY ["../../Neo/src/Neo.Endpoint/Neo.Endpoint.csproj", "../../Neo/src/Neo.Endpoint/"]
COPY ["../../Neo/src/Neo.Common/Neo.Common.csproj", "../../Neo/src/Neo.Common/"]

# Restore dependencies
RUN dotnet restore "src/CustomerPortal/Club.CustomerPortal.Api/Club.CustomerPortal.Api.csproj"

# Copy all source files
COPY . .

# Build
WORKDIR "/src/src/CustomerPortal/Club.CustomerPortal.Api"
RUN dotnet build "Club.CustomerPortal.Api.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "Club.CustomerPortal.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Club.CustomerPortal.Api.dll"]

