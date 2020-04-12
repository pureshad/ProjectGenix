using System;

namespace Genix.Core.Domain.Customers
{
    public class CustomerPassword : BaseEntity
    {
        public CustomerPassword()
        {
            PasswordFormat = PasswordFormat.Clear;
        }

        public PasswordFormat PasswordFormat
        {
            get => (PasswordFormat)PasswordFormatId;
            set => PasswordFormatId = (int)value;
        }

        public int CustomerId { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int PasswordFormatId { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
