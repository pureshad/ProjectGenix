using Genix.Core.Domain.Customers;

namespace Genix.Services.RequestsAndResults
{
    public class CustomerRegistrationRequest
    {
        public CustomerRegistrationRequest(Customer customer, string email, string userName, string password, PasswordFormat passwordFormat, bool isAproved = true)
        {
            Customer = customer;
            Email = email;
            UserName = userName;
            Password = password;
            PasswordFormat = passwordFormat;
            IsAproved = true; //TODO change logic
        }

        public Customer Customer { get; }
        public string Email { get; }
        public string UserName { get; }
        public string Password { get; }
        public PasswordFormat PasswordFormat { get; }
        public bool IsAproved { get; }
    }
}
