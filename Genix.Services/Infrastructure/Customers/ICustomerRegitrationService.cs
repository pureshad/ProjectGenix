namespace Genix.Services.Infrastructure.Customers
{
    public interface ICustomerRegitrationService
    {
        bool PasswordValidator(string current, string confirmCurrent);
    }
}
