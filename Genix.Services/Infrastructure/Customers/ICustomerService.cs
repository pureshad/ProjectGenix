using Genix.Core.Domain.Customers;
using System;
using System.Collections.Generic;

namespace Genix.Services.Infrastructure.Customers
{
    public interface ICustomerService
    {
        Customer GetCustomerByEmail(string email);
        Customer GetCustomerByUsername(string userName);
        Customer GetCustomerById(int id);
        Customer GetCustomerByGuid(Guid cutomerGuid);
        IList<CustomerPassword> GetCustomerPasswords(int? customerId = null,
            PasswordFormat? passwordFormat = null, int? passwordToReturn = null);

        CustomerPassword GetCurrentPassword(int customerId);
        void DeleteCustomer(Customer customer);
        void InsertCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomerRole(CustomerRole customer);
        CustomerRole GetCustomerRoleById(int customerRoleId);
        void InsertCustomerRole(CustomerRole customerRole);
        void UpdateCustomerRole(CustomerRole customerRole);
        void InsertCustomerPassword(CustomerPassword customerPassword);
        void UpdateCustomerPassword(CustomerPassword customerPassword);
    }
}
