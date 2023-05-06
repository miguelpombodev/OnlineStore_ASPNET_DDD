using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.DTO
{
    public class CreateCustomerDTO
    {

        [MinLength(3, ErrorMessage = "Name must be with 8 characters or longer"),
        MaxLength(15, ErrorMessage = "Name cannot be with more than 15 characters")]
        public string Name { get; set; }

        [MinLength(3, ErrorMessage = "Surname must be with 8 characters or longer"),
        MaxLength(100, ErrorMessage = "Surname cannot be with more than 15 characters")]
        public string Surname { get; set; }

        [StringLength(11, ErrorMessage = "CPF must have 11 characters")]
        public string CPF { get; set; }

        [EmailAddress(ErrorMessage = "Not valid email address")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Password must be with 8 characters or longer")]
        public string Password { get; set; }
    }
}