using Genix.Core.Domain.Customers;
using Genix.Services.Infrastructure.Customers;
using Genix.Services.RequestsAndResults;
using System;

namespace Genix.Services.Services.Customers
{
    public class CustomerRegitrationService : ICustomerRegitrationService
    {
        private readonly ICustomerService _customerService;

        public CustomerRegitrationService(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        public bool PasswordMatch(CustomerPassword customerPassword, string enteredPassword)
        {
            if (customerPassword == null || string.IsNullOrEmpty(enteredPassword))
                return false;

            var savedPassword = string.Empty;
            switch (customerPassword.PasswordFormat)
            {
                case PasswordFormat.Clear:
                    savedPassword = enteredPassword;
                    break;
                case PasswordFormat.Hashed:
                    //TODO
                    break;
                case PasswordFormat.Encrypted:
                    //TODO
                    break;
                default:
                    break;
            }

            if (customerPassword.Password == null)
                return false;

            return customerPassword.Password.Equals(savedPassword);
        }

        public bool PasswordValidator(string current, string confirmCurrent)
        {
            return current.Equals(confirmCurrent);
        }

        public CustomerRegistrationResult RegisterCustomer(CustomerRegistrationRequest request)
        {
            if (request is null)
                throw new System.ArgumentNullException(nameof(request));

            if (request.Customer is null)
                throw new ArgumentException("Can't load current customer");

            var result = new CustomerRegistrationResult();

            if (_customerService.GetCustomerByEmail(request.Email) != null)
            {
                result.AddError("Email already exists");
                return result;
            }
            if (_customerService.GetCustomerByUsername(request.UserName) != null)
            {
                result.AddError("This user name is already taken");
                return result;
            }

            request.Customer.UserName = request.UserName;
            request.Customer.Email = request.Email;

            var customerPassword = new CustomerPassword()
            {
                Customer = request.Customer,
                PasswordFormat = request.PasswordFormat,
                CreatedOnUtc = DateTime.Now
            };

            switch (request.PasswordFormat)
            {
                case PasswordFormat.Clear:
                    customerPassword.Password = request.Password;
                    break;
                case PasswordFormat.Hashed:
                    //TODO
                    break;
                case PasswordFormat.Encrypted:
                    //TODO
                    break;
                default:
                    customerPassword.Password = request.Password; //TODO EDIT
                    break;
            }

            _customerService.InsertCustomerPassword(customerPassword);

            request.Customer.Active = request.IsAproved;

            //TODO add registered roles
            //...

            _customerService.UpdateCustomer(request.Customer);
            return result;

        }

        public CustomerLoginResults ValidateCustomer(string userNameOrEmail, string password)
        {
            var customer = _customerService.GetCustomerByUsername(userNameOrEmail) == null
                ? _customerService.GetCustomerByEmail(userNameOrEmail) : null;

            if (customer == null)
                return CustomerLoginResults.CustomerNotExist;
            if (customer.Deleted)
                return CustomerLoginResults.Deleted;
            if (!customer.Active)
                return CustomerLoginResults.NotActive;

            if(!PasswordMatch(_customerService.GetCurrentPassword(customer.Id), password))
            {
                //TODO Fail login attempts

                //_customerService.UpdateCustomer(cutomer); //TODO update after trys
                return CustomerLoginResults.WrongPassword;
            }

            //TODO update login details
            //customer.FailedLoginAttempts = 0;
            //...
            //...
            //_customerService.UpdateCustomer(cutomer); //TODO update after trys

            return CustomerLoginResults.Successful;
        }
    }
}
