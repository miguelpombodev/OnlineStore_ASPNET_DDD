using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Services.Errors;
using OnlineStore.Services.Services;

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
        public async Task<IActionResult> GetById(
            Guid id,
            [FromServices] HttpClientService _httpClientService
        )
        {
            try
            {
                var product = await _service.GetById(id);
                var techInfos = await _httpClientService.GetAsync($"http://localhost:1337/api/technical-specification-infos?populate=*&filters[slug]={product.Sku}");
                return StatusCode(200, new
                {
                    product,
                    techInfos
                });
            }
            catch (ServiceError e)
            {
                return StatusCode(e.StatusCode, new { message = e.Message });
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Internal Server Error");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{e}");
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
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Internal Server Error");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{e}");
            }
        }

    }
}