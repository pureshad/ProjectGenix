using Genix.Core.Domain.Customers;
using Genix.Data.Infrastructure;
using Genix.Services.Infrastructure;
using Genix.Services.Infrastructure.Customers;
using Genix.Services.RequestsAndResults;
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
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName != null)
                    model.UserName = model.UserName.Trim();

                var registerationRequst = new CustomerRegistrationRequest(new Customer()
                {
                    UserName = model.UserName,
                    Active = model.Active,
                    CreatedOn = DateTime.Now,
                    Deleted = model.Deleted,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                }, model.Email, model.UserName, model.Password, PasswordFormat.Clear, model.Active);

                var registrationResult = _customerRegitrationService.RegisterCustomer(registerationRequst);
                if (registrationResult.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}