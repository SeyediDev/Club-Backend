# Club Backend

**Customer Loyalty Platform - Backend Services**

🔒 **Private Repository**

## Overview

Club Backend provides the core business logic and APIs for the Customer Loyalty Platform, built on **Neo Framework**.

## Architecture

```
Club.Backend/
├─ Club.Domain              → Domain entities, value objects
├─ Club.Application         → CQRS commands/queries, business logic
├─ Club.Infrastructure      → Data access, external services
├─ Club.Channel.Application → Channel-specific application logic
├─ Club.Channel.Api         → REST API endpoints
└─ Club.Bpms               → BPMN definitions and workflows
```

## Features

### Core Modules
- 👥 **Customer Management** - Customer profiles, segmentation
- 🎁 **Points & Rewards** - Point calculation, redemption
- 📦 **Products & Assets** - Product catalog, digital assets
- 🎲 **Promotions & Lottery** - Campaign management, lottery system
- 📊 **Scoring Rules** - Dynamic point calculation
- 📝 **Surveys & Feedback** - Customer surveys, feedback management
- 💬 **Forum & Community** - Discussion forums, Q&A

### Technical Features
- ✅ Clean Architecture with DDD
- ✅ CQRS with MediatR
- ✅ Built on Neo Framework
- ✅ Entity Framework Core
- ✅ Keycloak Authentication
- ✅ SMS Integration
- ✅ Background Jobs (Hangfire)
- ✅ Redis Caching

## Technology Stack

- **.NET 8.0**
- **Neo Framework** (Infrastructure)
- **SQL Server / PostgreSQL**
- **Redis**
- **Keycloak**
- **RabbitMQ**

## Getting Started

### Prerequisites

```bash
- .NET 8 SDK
- Docker & Docker Compose
- SQL Server or PostgreSQL
- Redis
- Keycloak
```

### Configuration

```bash
# 1. Clone repository
git clone https://github.com/Club-Apps/Club-Backend.git
cd Club-Backend

# 2. Restore packages
dotnet restore

# 3. Update connection strings in appsettings.json
# 4. Run migrations
dotnet ef database update --project src/Club.Infrastructure

# 5. Run API
cd src/Club.Channel.Api
dotnet run
```

### Environment Variables

```bash
ConnectionStrings__DefaultConnection=...
Keycloak__Authority=...
Redis__Configuration=...
```

## API Documentation

API documentation available at:
- Swagger: `https://localhost:5001/swagger`
- OpenAPI: `https://localhost:5001/swagger/v1/swagger.json`

## Development

### Build

```bash
dotnet build
```

### Run Tests

```bash
dotnet test
```

### Database Migrations

```bash
# Add migration
dotnet ef migrations add MigrationName --project src/Club.Infrastructure

# Update database
dotnet ef database update --project src/Club.Infrastructure
```

## Project Structure

```
src/
├─ Club.Domain/
│  ├─ Entities/          → Domain entities
│  ├─ ValueObjects/      → Value objects
│  ├─ Events/            → Domain events
│  └─ Repository/        → Repository interfaces
│
├─ Club.Application/
│  ├─ Features/          → CQRS features
│  │  ├─ Account/
│  │  ├─ Club/
│  │  ├─ Feedback/
│  │  ├─ Forum/
│  │  └─ Surveys/
│  └─ DependencyInjection.cs
│
├─ Club.Infrastructure/
│  ├─ Data/              → EF Core, repositories
│  └─ Features/          → External services
│
└─ Club.Channel.Api/
   ├─ Controllers/       → API endpoints
   └─ Program.cs
```

## Contributing

This is a private repository. For contribution guidelines, see [CONTRIBUTING.md](CONTRIBUTING.md).

## License

**Proprietary** - All rights reserved.

---

© 2024 Club Platform

