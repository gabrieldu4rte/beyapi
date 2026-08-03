# BeybladeX API

API REST pública e gratuita para consulta de peças Beyblade X, cobrindo os sistemas BX, UX, CX e CX/BX Expand-Infinity.

## Status

MVP em desenvolvimento. Único recurso disponível: consulta de peça por nome. Endpoints de listagem, filtros e busca textual estão previstos na arquitetura, mas ainda não implementados.

## Stack

- C# / .NET 10 — ASP.NET Core Web API
- Entity Framework Core 10 + Npgsql (PostgreSQL)
- FluentValidation
- Serilog
- Swashbuckle (Swagger / OpenAPI)
- Microsoft.AspNetCore.RateLimiting (nativo)

## Arquitetura

Clean Architecture, com dependências sempre apontando para dentro:

```
BeybladeX.Api            -> Application, Infrastructure (composição / injeção de dependência)
BeybladeX.Infrastructure -> Application, Domain
BeybladeX.Application    -> Domain
BeybladeX.Domain         -> (nenhuma dependência)
```

- **Domain**: entidade base abstrata `Peca` e oito subtipos (`LockChip`, `Blade`, `OverBlade`, `MetalBlade`, `AssistBlade`, `Ratchet`, `Bit`, `BladeRatchetIntegrada`), mapeados via EF Core TPH em uma única tabela (`pecas`), com coluna discriminadora `tipo_peca`.
- **Application**: `PecaService` concentra a regra de negócio; mapeamento manual de entidade para DTO (sem AutoMapper); paginação (`PagedResult<T>` / `PaginationParams`) já modelada para uso futuro.
- **Infrastructure**: `AppDbContext`, configuração via Fluent API (nomenclatura snake_case, enums persistidos como string), repositório com consultas somente leitura (`AsNoTracking()`).
- **Api**: controllers acessam apenas `IPecaService` — nunca o `DbContext` ou o repositório diretamente. Tratamento de erros centralizado em middleware, convertendo exceções de domínio e de validação em respostas HTTP apropriadas.

Regra de projeto: o MVP é somente leitura. Nenhuma operação de escrita é exposta pela API.

## Endpoint disponível

```
GET /api/v1/pecas/{nome}
```

Busca case-insensitive pelo nome da peça.

| Código | Condição |
|--------|----------|
| 200 | Peça encontrada |
| 400 | Nome vazio, em branco ou com mais de 120 caracteres |
| 404 | Peça não encontrada |

## Pré-requisitos

- .NET 10 SDK
- PostgreSQL em execução localmente (ou acessível via connection string)

## Configuração local

O arquivo `appsettings.json` de cada ambiente não é versionado. Crie `src/BeybladeX.Api/appsettings.Development.json` com a connection string do seu banco, por exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=beybladedb;Username=postgres;Password=postgres"
  }
}
```

## Executando o projeto

Aplicar as migrations:

```bash
dotnet ef database update --project src/BeybladeX.Infrastructure --startup-project src/BeybladeX.Api
```

Iniciar a API:

```bash
dotnet run --project src/BeybladeX.Api
```

Recursos disponíveis em desenvolvimento:

- Swagger UI: `/swagger`
- Health check: `/health`
