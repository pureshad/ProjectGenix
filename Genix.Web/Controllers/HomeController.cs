using Genix.Core.Domain.Customers;
using Genix.Data.Infrastructure;
using Genix.Services.Infrastructure.Authentication;
using Genix.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Genix.Web.Controllers
{
    public class HomeController : BaseController
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<CustomerRole> _customerRoleRepository;
        private readonly IGenixAuthenticationService genixAuthenticationService;

        public HomeController(IRepository<Customer> customerRepository,
            IRepository<CustomerRole> customerRoleRepository, IGenixAuthenticationService genixAuthenticationService)
        {
            //_logger = logger;
            this._customerRepository = customerRepository;
            this._customerRoleRepository = customerRoleRepository;
            this.genixAuthenticationService = genixAuthenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }

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
