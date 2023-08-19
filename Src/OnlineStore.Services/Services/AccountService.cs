using OnlineStore.Domain.DTO.Account;
using OnlineStore.Domain.DTO.Customers;
using OnlineStore.Domain.Interfaces.Repositories;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Domain.Models;

namespace OnlineStore.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly ICustomerRepository _repository;
        public AccountService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Login(CustomerLoginDTO customer)
        {
            var registeredCustomer = await _repository.GetByEmailAsync(customer.Email);

            if (registeredCustomer == null)
            {
                throw new NullReferenceException("Customer does not found!");
            }

            var validatedUserPassword = BCrypt.Net.BCrypt.Verify(customer.Password, registeredCustomer.Password);

            if (validatedUserPassword == false)
            {
                throw new Exception("Password incorrect");
            }

            return registeredCustomer;
        }

        public async Task<Customer> GenerateNewPassword(ForgotPasswordDTO customer)
        {
            var validateCustomerEmail = await _repository.GetByEmailAsync(customer.Email);

            if (validateCustomerEmail == null)
            {
                throw new NullReferenceException("Customer does not found!");
            }

            var newPassword = BCrypt.Net.BCrypt.HashPassword(customer.NewPassword);

            validateCustomerEmail.Password = newPassword;

            var updatedUser = await _repository.UpdateAsync(validateCustomerEmail);

            return updatedUser;
        }
    }
}