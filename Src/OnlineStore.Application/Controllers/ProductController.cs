using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Interfaces.Services;

namespace OnlineStore.Application.Controllers
{
    [Route("v1/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllProduct(
            [FromQuery] int? type_id,
            [FromQuery] int? brand_id,
            [FromQuery] decimal? priceStarts,
            [FromQuery] decimal? priceEnds,
            [FromQuery] string orderBy = "asc"
        )
        {
            return Ok(await _service.GetAllProducts(type_id, brand_id, priceStarts, priceEnds, orderBy));
        }

    }
}