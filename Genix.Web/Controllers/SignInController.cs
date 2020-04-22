using Genix.Services.Infrastructure.Authentication;
using Genix.Services.Infrastructure.Customers;
using Genix.Services.Infrastructure.Messages;
using Genix.Web.Models.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Genix.Web.Controllers
{
    public class SignInController : BaseController
    {
        private readonly ICustomerRegitrationService _customerRegitrationService;
        private readonly IGenixAuthenticationService _authenticationService;
        private readonly ICustomerService _customerService;
        private readonly INotificationService _notificationService;

        public SignInController(ICustomerRegitrationService customerRegitrationService,
            IGenixAuthenticationService authenticationService,
            ICustomerService customerService,
            INotificationService notificationService)
        {
            _customerRegitrationService = customerRegitrationService;
            _authenticationService = authenticationService;
            _customerService = customerService;
            _notificationService = notificationService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(LoginModel model, string returnUrl)
        {
            if (model.Email != null)
            {
                model.Email = model.Email.Trim();
            }


            //returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var loginResult = _customerRegitrationService.ValidateCustomer(model.Email, model.Password);

                var customerEmail = _customerService.GetCustomerByEmail(model.Email);
                var customerUserName = _customerService.GetCustomerByUsername(model.Email);

                var customer = customerEmail ?? customerUserName;
                switch (loginResult)
                {
                    case Core.Domain.Customers.CustomerLoginResults.Successful:
                        _authenticationService.SignIn(customer, model.RememberMe);
                        if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                            return RedirectToAction("Index", "Home");

                        return Redirect(returnUrl);

                    case Core.Domain.Customers.CustomerLoginResults.CustomerNotExist:
                        ModelState.AddModelError("", "CustomerNotExist");
                        break;
                    case Core.Domain.Customers.CustomerLoginResults.WrongPassword:
                        ModelState.AddModelError("", "WrongPassword");
                        break;
                    case Core.Domain.Customers.CustomerLoginResults.NotActive:
                        ModelState.AddModelError("", "NotActive");
                        break;
                    case Core.Domain.Customers.CustomerLoginResults.Deleted:
                        ModelState.AddModelError("", "Deleted");
                        break;
                    case Core.Domain.Customers.CustomerLoginResults.NotRegistered:
                        ModelState.AddModelError("", "NotRegistered");
                        break;
                    case Core.Domain.Customers.CustomerLoginResults.LockedOut:
                        ModelState.AddModelError("", "LockedOut");
                        break;
                    default:
                        ModelState.AddModelError("", "Something is wrong");
                        _notificationService.ErrorNotification("An error accured, please try again");
                        break;
                }
            }

            //something went wrong
            return View(model);
        }

        public IActionResult SignOut()
        {
            _authenticationService.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}