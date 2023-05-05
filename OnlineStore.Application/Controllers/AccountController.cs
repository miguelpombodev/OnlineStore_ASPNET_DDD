using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.DTO.Customers;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Services.Services;

namespace OnlineStore.Application.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ICustomerService _service;

        public AccountController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> CreateCustomer(
            [FromBody] CustomerLoginDTO customer,
            [FromServices] TokenService _tokenService)
        {
            var registeredCustomer = await _service.GetByEmail(customer.Email);
            var generatedToken = _tokenService.GenerateToken(customer, registeredCustomer);

            return Ok(new
            {
                customer,
                token = generatedToken
            });
        }
    }
}