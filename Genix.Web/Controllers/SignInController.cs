using Microsoft.AspNetCore.Mvc;

namespace Genix.Web.Controllers
{
    public class SignInController : BaseController
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {

            return View();
        }
    }
}