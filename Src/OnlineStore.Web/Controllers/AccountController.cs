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
        private IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> CreateCustomer(
            [FromBody] CustomerLoginDTO customer,
            [FromServices] TokenService _tokenService)
        {
            var registeredCustomer = await _service.Login(customer);
            var generatedToken = _tokenService.GenerateToken(registeredCustomer);

            return Ok(new
            {
                customer,
                token = generatedToken
            });
        }
    }
}