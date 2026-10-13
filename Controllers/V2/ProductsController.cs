using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Dtos;
using ProductsApi.Services;

namespace ProductsApi.Controllers.V2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service) => _service = service;

    [HttpGet]
    public ActionResult<IEnumerable<ProductV2Dto>> GetAll()
    {
        var result = _service.GetAll()
            .Select(p => new ProductV2Dto(p.Id, p.Name, p.Price, p.Category.Name));
        return Ok(result);
    }

 
    [HttpGet("{id:int}")]
    public ActionResult<ProductV2Dto> GetById(int id)
    {
        var p = _service.GetById(id);
        return p is null
            ? NotFound()
            : Ok(new ProductV2Dto(p.Id, p.Name, p.Price, p.Category.Name));
    }
}
