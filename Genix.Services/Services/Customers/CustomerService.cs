using Genix.Core.Domain.Customers;
using Genix.Data.Infrastructure;
using Genix.Services.Infrastructure.Customers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Genix.Services.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<CustomerPassword> _customerPasswordRepository;
        private readonly IRepository<CustomerRole> _customerRoleRepository;

        public CustomerService(IRepository<Customer> customerRepository,
            IRepository<CustomerPassword> customerPasswordRepository,
            IRepository<CustomerRole> customerRoleRepository)
        {
            _customerRepository = customerRepository;
            this._customerPasswordRepository = customerPasswordRepository;
            this._customerRoleRepository = customerRoleRepository;
        }

        public void DeleteCustomer(Customer customer)
        {
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            _customerRepository.Delete(customer);
        }

        public void DeleteCustomerRole(CustomerRole customer)
        {
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            _customerRoleRepository.Delete(customer);
        }

        public CustomerPassword GetCurrentPassword(int customerId)
        {
            if (customerId == 0)
                return null;

            return GetCustomerPasswords(customerId, passwordToReturn: 1).FirstOrDefault();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _customerRepository.Table.Where(w => w.Email == email).FirstOrDefault();
        }

        public Customer GetCustomerByGuid(Guid cutomerGuid)
        {
            return _customerRepository.Table.Where(w => w.CustomerGuid.Equals(cutomerGuid)).FirstOrDefault();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.Table.Where(w => w.Id == id).FirstOrDefault();
        }

        public Customer GetCustomerByUsername(string userName)
        {
            return _customerRepository.Table.Where(w => w.UserName.Equals(userName)).FirstOrDefault();
        }

        public IList<CustomerPassword> GetCustomerPasswords(int? customerId = null, PasswordFormat? passwordFormat = null, int? passwordToReturn = null)
        {
            var query = _customerPasswordRepository.Table;

            if (customerId.HasValue)
                query = query.Where(w => w.CustomerId == customerId.Value);

            if (passwordFormat.HasValue)
                query = query.Where(w => w.PasswordFormat == passwordFormat.Value);

            if (passwordToReturn.HasValue)
                query = query.OrderByDescending(w => w.CreatedOnUtc).Take(passwordToReturn.Value);

            return query.ToList();
        }

        public CustomerRole GetCustomerRoleById(int customerRoleId)
        {
            if (customerRoleId == 0)
                return null;

            return _customerRoleRepository.GetById(customerRoleId);
        }

        public void InsertCustomer(Customer customer)
        {
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            _customerRepository.Insert(customer);
        }

        public void InsertCustomerPassword(CustomerPassword customerPassword)
        {
            if (customerPassword is null)
                throw new ArgumentNullException(nameof(customerPassword));

            _customerPasswordRepository.Insert(customerPassword);
        }

        public void InsertCustomerRole(CustomerRole customerRole)
        {
            if (customerRole is null)
                throw new ArgumentNullException(nameof(customerRole));

            _customerRoleRepository.Insert(customerRole);
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            _customerRepository.Update(customer);
        }

        public void UpdateCustomerPassword(CustomerPassword customerPassword)
        {
            if (customerPassword is null)
                throw new ArgumentNullException(nameof(customerPassword));

            _customerPasswordRepository.Update(customerPassword);
        }

        public void UpdateCustomerRole(CustomerRole customerRole)
        {
            if (customerRole is null)
                throw new ArgumentNullException(nameof(customerRole));

            _customerRoleRepository.Update(customerRole);
        }
    }
}
