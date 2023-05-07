using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.DTO;
using OnlineStore.Domain.Interfaces.Services;

namespace OnlineStore.Application.Controllers
{
    [Route("v1/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDTO customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values);
                }

                return Ok(await _service.SaveCustomer(customer));

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}