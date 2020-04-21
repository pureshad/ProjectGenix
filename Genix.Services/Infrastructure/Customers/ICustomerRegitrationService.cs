using Genix.Core.Domain.Customers;
using Genix.Services.RequestsAndResults;

namespace Genix.Services.Infrastructure.Customers
{
    public interface ICustomerRegitrationService
    {
        bool PasswordValidator(string current, string confirmCurrent);
        CustomerLoginResults ValidateCustomer(string userNameOrEmail, string password);

        bool PasswordMatch(CustomerPassword customerPassword, string enteredPassword);

        CustomerRegistrationResult RegisterCustomer(CustomerRegistrationRequest customer);
    }
}
