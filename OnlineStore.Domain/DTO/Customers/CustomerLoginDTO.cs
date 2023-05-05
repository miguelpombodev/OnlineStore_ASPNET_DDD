using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.DTO.Customers
{
    public class CustomerLoginDTO
    {
        [EmailAddress(ErrorMessage = "Not valid email address")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Password must be with 8 characters or longer")]
        public string Password { get; set; }
    }
}