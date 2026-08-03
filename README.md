# BeybladeX API

Free, public REST API for looking up Beyblade X parts, covering the BX, UX, CX and CX/BX Expand-Infinity systems.

## Status

MVP under development. Only resource currently available: look up a part by name. Listing endpoints, filters, and text search are planned in the architecture but not yet implemented.

## Stack

- C# / .NET 10 — ASP.NET Core Web API
- Entity Framework Core 10 + Npgsql (PostgreSQL)
- FluentValidation
- Serilog
- Swashbuckle (Swagger / OpenAPI)
- Microsoft.AspNetCore.RateLimiting (built-in)

## Architecture

Clean Architecture, with dependencies always pointing inward:

```
BeybladeX.Api            -> Application, Infrastructure (composition / dependency injection only)
BeybladeX.Infrastructure -> Application, Domain
BeybladeX.Application    -> Domain
BeybladeX.Domain         -> (no dependencies)
```

- **Domain**: abstract base entity `Peca` and eight subtypes (`LockChip`, `Blade`, `OverBlade`, `MetalBlade`, `AssistBlade`, `Ratchet`, `Bit`, `BladeRatchetIntegrada`), mapped via EF Core TPH into a single table (`pecas`), with a discriminator column (`tipo_peca`).
- **Application**: `PecaService` holds the business logic; entity-to-DTO mapping is manual (no AutoMapper); pagination (`PagedResult<T>` / `PaginationParams`) is already modeled for future use.
- **Infrastructure**: `AppDbContext`, Fluent API configuration (snake_case naming, enums persisted as strings), read-only repository queries (`AsNoTracking()`).
- **Api**: controllers only depend on `IPecaService` — never the `DbContext` or the repository directly. Error handling is centralized in middleware, converting domain and validation exceptions into the appropriate HTTP responses.

Project rule: the MVP is read-only. No write operations are exposed by the API.

## Available endpoint

```
GET /api/v1/pecas/{nome}
```

Case-insensitive lookup by part name.

| Code | Condition |
|------|-----------|
| 200 | Part found |
| 400 | Name empty, blank, or longer than 120 characters |
| 404 | Part not found |

## Prerequisites

- .NET 10 SDK
- PostgreSQL running locally (or reachable via connection string)

## Local setup

The `appsettings.json` file for each environment is not versioned. Create `src/BeybladeX.Api/appsettings.Development.json` with your database connection string, for example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=beybladedb;Username=postgres;Password=postgres"
  }
}
```

## Running the project

Apply migrations:

```bash
dotnet ef database update --project src/BeybladeX.Infrastructure --startup-project src/BeybladeX.Api
```

Start the API:

```bash
dotnet run --project src/BeybladeX.Api
```

Available in development:

- Swagger UI: `/swagger`
- Health check: `/health`
