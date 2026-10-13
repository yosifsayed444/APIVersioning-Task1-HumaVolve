# Task 1 — Implement API Versioning (Products API)

**Author:** Youssef Elsayed
**Stack:** ASP.NET Core 8 Web API, `Asp.Versioning.Mvc`, Swagger

## Run

```bash
dotnet restore
dotnet run
```

Open Swagger at `https://localhost:7100/swagger` (a dropdown switches between V1 and V2).

## Endpoints

| Version | Endpoint | Response item |
|---------|----------|---------------|
| v1 | `GET /api/v1/products` | `{ "id", "name", "price" }` |
| v2 | `GET /api/v2/products` | `{ "id", "name", "price", "categoryName" }` |

Both versions also expose `GET /api/v{n}/products/{id}`.

### v1 sample
```json
[ { "id": 1, "name": "Laptop", "price": 25000 } ]
```

### v2 sample
```json
[ { "id": 1, "name": "Laptop", "price": 25000, "categoryName": "Electronics" } ]
```

## How it satisfies the requirements

1. **API Versioning set up** — `AddApiVersioning` + `AddApiExplorer` in `Program.cs`, using URL-segment versioning (`/api/v1/...`, `/api/v2/...`).
2. **v1 returns the old shape** — `Controllers/V1/ProductsController.cs` maps to `ProductV1Dto` (unchanged contract).
3. **v2 adds `CategoryName`** — `Controllers/V2/ProductsController.cs` maps to `ProductV2Dto`.
4. **Both versions work independently** — separate controllers and DTOs, one shared `IProductService`. Changing v2 can never break v1.
   `ReportApiVersions = true` adds `api-supported-versions` response headers; unversioned calls default to v1 so existing clients are unaffected.

## Structure

```
Controllers/V1/ProductsController.cs
Controllers/V2/ProductsController.cs
Dtos/ProductDtos.cs
Models/Product.cs
Services/ProductService.cs      (in-memory data)
Swagger/ConfigureSwaggerOptions.cs
Program.cs
```
# APIVersioning-Task1-HumaVolve
