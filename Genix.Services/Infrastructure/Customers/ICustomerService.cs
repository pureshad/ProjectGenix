using Genix.Core.Domain.Customers;
using System;

namespace Genix.Services.Infrastructure.Customers
{
    public interface ICustomerService
    {
        Customer GetCustomerByEmail(string email);
        Customer GetCustomerByUsername(string userName);
        Customer GetCustomerById(int id);
        Customer GetCustomerByGuid(Guid cutomerGuid);
    }
}
