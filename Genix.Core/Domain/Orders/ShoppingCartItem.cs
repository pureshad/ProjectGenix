using Genix.Core.Domain.Catalog;
using Genix.Core.Domain.Customers;
using System;

namespace Genix.Core.Domain.Orders
{
    public class ShoppingCartItem : BaseEntity
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
