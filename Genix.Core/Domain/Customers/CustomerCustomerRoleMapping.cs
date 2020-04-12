namespace Genix.Core.Domain.Customers
{
    public class CustomerCustomerRoleMapping : BaseEntity
    {
        public int CustomerId { get; set; }
        public int CustomerRoleId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual CustomerRole CustomerRole { get; set; }
    }
}
