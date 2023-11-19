using System.Net.Mail;
using System.Text.Json;
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
        private readonly ICustomerService _customerService;

        public AccountController(IAccountService service, ICustomerService customerService)
        {
            _service = service;
            _customerService = customerService;
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

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword(
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

        [HttpGet("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] JsonElement jsonElement, [FromServices] EmailService _emailService)
        {
            try
            {
                var customerEmailValidated = await _customerService.GetByEmail(jsonElement.GetProperty("email").ToString());

                _emailService.SendEmail(
                    "from@example.com",
                    customerEmailValidated.Email,
                    "Your email exists!",
                    "Here's a email body message to tell you that your email exists XD"
                );

                return Ok(new
                {
                    message = "Email sent!"
                });

            }
            catch (NullReferenceException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    error = ex.Message
                });
            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    error = ex.Message
                });

            }
            catch (SmtpException ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    error = ex.Message
                });
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    error = "Internal Server Error"
                });
            }
        }
    }
}