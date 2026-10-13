using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Dtos;
using ProductsApi.Services;

namespace ProductsApi.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service) => _service = service;

    [HttpGet]
    public ActionResult<IEnumerable<ProductV1Dto>> GetAll()
    {
        var result = _service.GetAll()
            .Select(p => new ProductV1Dto(p.Id, p.Name, p.Price));
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public ActionResult<ProductV1Dto> GetById(int id)
    {
        var p = _service.GetById(id);
        return p is null ? NotFound() : Ok(new ProductV1Dto(p.Id, p.Name, p.Price));
    }
}
