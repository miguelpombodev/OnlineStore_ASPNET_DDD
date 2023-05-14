using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Services.Errors;

namespace OnlineStore.Application.Controllers
{
    [Route("v1/products")]
    [ApiController]
    [Authorize]
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
            try
            {
                var product = await _service.GetById(id);
                return StatusCode(200, product);
            }
            catch (ServiceError e)
            {
                return StatusCode(e.StatusCode, e.Message);
            }
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
            try
            {
                return Ok(await _service.GetAllProducts(type_id, brand_id, priceStarts, priceEnds, orderBy));
            }
            catch (ServiceError e)
            {
                return StatusCode(e.StatusCode, e.Message);
            }
        }

    }
}