using Genix.Core.Domain.Customers;
using Genix.Core.Domain.Notification;
using Genix.Data.Infrastructure;
using Genix.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Genix.Web.Controllers
{
    public class HomeController : BaseController
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<CustomerRole> _customerRoleRepository;

        public HomeController(IRepository<Customer> customerRepository, 
            IRepository<CustomerRole> customerRoleRepository)
        {
            //_logger = logger;
            this._customerRepository = customerRepository;
            this._customerRoleRepository = customerRoleRepository;
        }

        public IActionResult Index()
        {
            //var users = _customerRepository.Table.ToList();
            //var users = _customerRoleRepository.Table.ToList();
            //AddNotification(NotificationType.LoginSuccess, "Redirected to home");
            return View();
        }

        //[HttpPost]
        //public IActionResult AddUser(UserModel model)
        //{
        //    _userRepository.Insert(new User()
        //    {
        //        Email = model.Email,
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        PhoneNumber = model.PhoneNumber
        //    });
        //    return Ok();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
