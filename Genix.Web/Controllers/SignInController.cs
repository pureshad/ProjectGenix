using Genix.Services.Infrastructure.Customers;
using Genix.Web.Models.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Genix.Web.Controllers
{
    public class SignInController : BaseController
    {
        private readonly ICustomerRegitrationService _customerRegitrationService;

        public SignInController(ICustomerRegitrationService customerRegitrationService)
        {
            this._customerRegitrationService = customerRegitrationService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(LoginModel model)
        {
            if (model.Email != null)
            {
                model.Email = model.Email.Trim();
            }

            if (ModelState.IsValid)
            {
                var loginResult = _customerRegitrationService.ValidateCustomer(model.Email, model.Password);
                switch (loginResult)
                {
                    case Core.Domain.Customers.CustomerLoginResults.Successful:
                        return RedirectToAction("Index", "Home");
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
                        break;
                }
            }

            //something went wrong
            return View(model);
        }
    }
}