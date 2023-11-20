using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Services.Errors;
using OnlineStore.Services.Services;

namespace OnlineStore.Web.Controllers
{
    [Route("v1/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICartService _service;


        public CartController(ICustomerService customerService, ICartService service)
        {
            _customerService = customerService;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> GetOrCreateCart(
            [FromServices] TokenService _tokenService
        )
        {
            try
            {
                var userEmail = _tokenService.DecodeToken(Request.Headers.Authorization);
                var existedCustomer = await _customerService.GetByEmail(userEmail);

                var userCart = await _service.GetCartOrCreateAsync(existedCustomer.Id);

                return StatusCode(StatusCodes.Status200OK, userCart);
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
    }
}