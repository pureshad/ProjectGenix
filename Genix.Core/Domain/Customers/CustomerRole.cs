namespace Genix.Core.Domain.Customers
{
    public class CustomerRole : BaseEntity
    {
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
