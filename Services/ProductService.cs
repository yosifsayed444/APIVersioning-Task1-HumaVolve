using ProductsApi.Models;

namespace ProductsApi.Services;

public interface IProductService
{
    IReadOnlyList<Product> GetAll();
    Product? GetById(int id);
}

public class ProductService : IProductService
{
    private static readonly Category Electronics = new() { Id = 1, Name = "Electronics" };
    private static readonly Category Accessories = new() { Id = 2, Name = "Accessories" };

    private static readonly List<Product> Products = new()
    {
        new Product { Id = 1, Name = "Laptop",   Price = 25000, Category = Electronics },
        new Product { Id = 2, Name = "Phone",    Price = 15000, Category = Electronics },
        new Product { Id = 3, Name = "Mouse",    Price = 400,   Category = Accessories }
    };

    public IReadOnlyList<Product> GetAll() => Products;

    public Product? GetById(int id) => Products.FirstOrDefault(p => p.Id == id);
}
