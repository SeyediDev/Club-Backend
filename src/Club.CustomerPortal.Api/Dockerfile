# Base stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["Club.CustomerPortal/Club.CustomerPortal.Api/Club.CustomerPortal.Api.csproj", "Club.CustomerPortal/Club.CustomerPortal.Api/"]
COPY ["Club.CustomerPortal/Club.CustomerPortal.Application/Club.CustomerPortal.Application.csproj", "Club.CustomerPortal/Club.CustomerPortal.Application/"]
COPY ["Club/src/Club.Domain/Club.Domain.csproj", "Club/src/Club.Domain/"]
COPY ["Club/src/Club.Infrastructure/Club.Infrastructure.csproj", "Club/src/Club.Infrastructure/"]
COPY ["Club/src/Club.Application/Club.Application.csproj", "Club/src/Club.Application/"]
COPY ["Cando/Cando.Domain/Cando.Domain.csproj", "Cando/Cando.Domain/"]
COPY ["Cando/Cando.Application/Cando.Application.csproj", "Cando/Cando.Application/"]
COPY ["Cando/Cando.Infrastructure/Cando.Infrastructure.csproj", "Cando/Cando.Infrastructure/"]
COPY ["Cando/Cando.Endpoint/Cando.Endpoint.csproj", "Cando/Cando.Endpoint/"]
COPY ["Cando/Cando.Common/Cando.Common.csproj", "Cando/Cando.Common/"]

# Restore dependencies
RUN dotnet restore "Club.CustomerPortal/Club.CustomerPortal.Api/Club.CustomerPortal.Api.csproj"

# Copy all source files
COPY . .

# Build
WORKDIR "/src/Club.CustomerPortal/Club.CustomerPortal.Api"
RUN dotnet build "Club.CustomerPortal.Api.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "Club.CustomerPortal.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Club.CustomerPortal.Api.dll"]

