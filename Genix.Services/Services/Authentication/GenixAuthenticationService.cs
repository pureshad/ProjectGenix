using Genix.Core.Domain.Customers;
using Genix.Services.Infrastructure.Authentication;
using Genix.Services.Infrastructure.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Genix.Services.Services.Authentication
{
    public class GenixAuthenticationService : IGenixAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICustomerService _customerService;
        private Customer _cachedCustomer;

        public GenixAuthenticationService(IHttpContextAccessor httpContextAccessor,
            ICustomerService customerService)
        {
            _httpContextAccessor = httpContextAccessor;
            _customerService = customerService;
        }

        public async void SignIn(Customer customer, bool isPersistent)
        {
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(customer.UserName))
                claims.Add(new Claim(ClaimTypes.Name, customer.UserName, ClaimValueTypes.String, GenixAuthenticationDefaults.ClaimsIssuer));

            if (!string.IsNullOrEmpty(customer.Email))
                claims.Add(new Claim(ClaimTypes.Email, customer.Email, ClaimValueTypes.Email, GenixAuthenticationDefaults.ClaimsIssuer));

            var userIdentity = new ClaimsIdentity(claims, GenixAuthenticationDefaults.AuthenticationScheme);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            var authenticationProperty = new AuthenticationProperties()
            {
                IsPersistent = isPersistent,
                IssuedUtc = DateTime.Now
            };
            
            await _httpContextAccessor.HttpContext.SignInAsync(GenixAuthenticationDefaults.AuthenticationScheme, userPrincipal, authenticationProperty);

            _cachedCustomer = customer;
        }

        public async void SignOut()
        {
            _cachedCustomer = null;
            await _httpContextAccessor.HttpContext.SignOutAsync(GenixAuthenticationDefaults.AuthenticationScheme);
        }
 
        public Customer GetAuthenticatedCustomer()
        {
            throw new NotImplementedException();
        }

    }
}
