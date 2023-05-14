using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.DTO;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Services.Services;

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

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetById(
            [FromServices] TokenService tokenService
        )
        {
            try
            {
                var email = tokenService.DecodeToken(Request.Headers.Authorization);
                return Ok(await _service.GetByEmail(email));

            }
            catch (System.Exception)
            {

                throw;
            }
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