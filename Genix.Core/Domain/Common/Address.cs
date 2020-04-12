using Genix.Core.Domain.Directory;
using System;

namespace Genix.Core.Domain.Common
{
    public class Address : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PhoneNumber { get; set; }
        public int? CountryId { get; set; }
        public int? StateProvinceId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public virtual Country Country { get; set; }
        public virtual StateProvince StateProvince { get; set; }
    }
}
