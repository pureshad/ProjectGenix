using Genix.Core.Domain.Common;

namespace Genix.Core.Domain.Customers
{
    public class CustomerAddressMapping : BaseEntity
    {
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Address Address { get; set; }
    }
}
