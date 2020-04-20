using Genix.Core.Domain.Customers;
using Genix.Data.Infrastructure;
using Genix.Services.Infrastructure;
using Genix.Services.Infrastructure.Customers;
using Genix.Web.Models.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Genix.Web.Controllers
{
    public class RegisterController : BaseController
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly ICustomerRegitrationService _customerRegitrationService;
        private readonly ICustomerService _customerService;
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(IRepository<Customer> customerRepository,
            ICustomerRegitrationService customerRegitrationService,
            ICustomerService customerService,
            ILogger<RegisterController> logger)
        {
            _customerRepository = customerRepository;
            _customerRegitrationService = customerRegitrationService;
            _customerService = customerService;
            this._logger = logger;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel customer)
        {
            var message = string.Empty;

            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var user = _customerService.GetCustomerByEmail(customer.Email);
            if (user != null)
            {
                message = "User already defined";
                //AddNotification(NotificationType.RegisterError, message);

                ModelState.AddModelError("", message);
                return View();
            }

            if (!_customerRegitrationService.PasswordValidator(customer.Password, customer.ConfirmPassword))
            {
                message = "Password doesn't match";
                //AddNotification(NotificationType.RegisterError, message);

                ModelState.AddModelError("", message);
                return View();
            }

            //_customerRepository.Insert(new Customer()
            //{
            //    UserName = customer.UserName,
            //    Active = true,
            //    CreatedOn = DateTime.Now,
            //    Deleted = false,
            //    Email = customer.Email,
            //    PhoneNumber = customer.PhoneNumber
            //});
            message = "User created successfully";
            //AddNotification(NotificationType.RegisterSuccess, message);


            return RedirectToAction("Index", "Home");
        }
    }
}