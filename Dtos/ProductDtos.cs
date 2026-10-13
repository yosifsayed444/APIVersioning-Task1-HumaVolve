namespace ProductsApi.Dtos;

// v1 contract: unchanged, so existing clients keep working.
public record ProductV1Dto(int Id, string Name, decimal Price);

// v2 contract: same fields + CategoryName.
public record ProductV2Dto(int Id, string Name, decimal Price, string CategoryName);
