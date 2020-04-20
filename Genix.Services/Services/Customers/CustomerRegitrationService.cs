using Genix.Services.Infrastructure.Customers;

namespace Genix.Services.Services.Customers
{
    public class CustomerRegitrationService : ICustomerRegitrationService
    {
        public bool PasswordValidator(string current, string confirmCurrent)
        {
            return current.Equals(confirmCurrent);
        }
    }
}
