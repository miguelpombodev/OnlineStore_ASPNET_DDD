using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Services;

namespace OnlineStore.Application.Controllers
{
    [Route("v1/product")]
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

    }
}