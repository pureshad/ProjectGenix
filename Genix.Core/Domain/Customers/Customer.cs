using Genix.Core.Domain.Common;
using Genix.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Genix.Core.Domain.Customers
{
    public class Customer : BaseEntity
    {
        private ICollection<ShoppingCartItem> _shoppingCartItems;
        private ICollection<CustomerAddressMapping> _customerAddressMappings;
        private IList<CustomerRole> _customerRoles;
        private ICollection<CustomerCustomerRoleMapping> _customerCustomerRoleMappings;

        public Customer()
        {
            CustomerGuid = Guid.NewGuid();
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int OrderId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public int? ShippingAddressId { get; set; }
        public Guid CustomerGuid { get; set; }
        public int? BillingAddressId { get; set; }

        public virtual Address ShippingAddress { get; set; }
        public virtual Address BillingAddress { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems
        {
            get => _shoppingCartItems ?? (_shoppingCartItems = new List<ShoppingCartItem>());
            protected set => _shoppingCartItems = value;
        }
        public virtual ICollection<CustomerAddressMapping> CustomerAddressMappings
        {
            get => _customerAddressMappings ?? (_customerAddressMappings = new List<CustomerAddressMapping>());
            protected set => _customerAddressMappings = value;
        }
        public virtual IList<CustomerRole> CustomerRoles
        {
            get => _customerRoles ?? (_customerRoles = CustomerCustomerRoleMappings.Select(mapping => mapping.CustomerRole).ToList());
        }
        public virtual ICollection<CustomerCustomerRoleMapping> CustomerCustomerRoleMappings
        {
            get => _customerCustomerRoleMappings ?? (_customerCustomerRoleMappings = new List<CustomerCustomerRoleMapping>());
            protected set => _customerCustomerRoleMappings = value;
        }
    }
}
