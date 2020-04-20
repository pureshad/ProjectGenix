using Genix.Core.Domain.Customers;
using Genix.Data.Infrastructure;
using Genix.Services.Infrastructure.Customers;
using System;
using System.Linq;

namespace Genix.Services.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
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
    }
}
