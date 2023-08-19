using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.DTO.Account;
using OnlineStore.Domain.DTO.Customers;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Services.Services;

namespace OnlineStore.Application.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> CreateCustomer(
            [FromBody] CustomerLoginDTO customer,
            [FromServices] TokenService _tokenService)
        {
            try
            {
                var registeredCustomer = await _service.Login(customer);
                var generatedToken = _tokenService.GenerateToken(registeredCustomer);

                return Ok(new
                {
                    token = generatedToken
                });

            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
            catch (NullReferenceException nullEx)
            {
                return StatusCode(StatusCodes.Status404NotFound, nullEx.Message);
            }
        }

        [HttpPut("forgot-password")]
        public async Task<IActionResult> ForgotPassword(
            [FromBody] ForgotPasswordDTO customer
        )
        {
            try
            {

                var newCustomerPassword = await _service.GenerateNewPassword(customer);

                return StatusCode(StatusCodes.Status200OK, new
                {
                    newCustomerPassword
                });

            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
            catch (NullReferenceException nullEx)
            {
                return StatusCode(StatusCodes.Status404NotFound, nullEx.Message);
            }
        }
    }
}