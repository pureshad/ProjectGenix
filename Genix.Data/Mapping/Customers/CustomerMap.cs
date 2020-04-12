using Genix.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Customers
{
    public class CustomerMap : GenixEntityTypeConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));
            builder.HasKey(customer => customer.Id);

            builder.Property(customer => customer.UserName).HasMaxLength(1000);
            builder.Property(customer => customer.Email).HasMaxLength(1000).IsRequired();
            builder.Property(customer => customer.PhoneNumber).HasMaxLength(100);

            builder.Property(customer => customer.BillingAddressId).HasColumnName("BillingAddress_Id");
            builder.Property(customer => customer.ShippingAddressId).HasColumnName("ShippingAddress_Id");

            builder.HasOne(customer => customer.BillingAddress).WithMany().HasForeignKey(customer =>
            customer.BillingAddressId);

            builder.HasOne(customer => customer.ShippingAddress).WithMany()
                .HasForeignKey(customer => customer.ShippingAddressId);

            builder.Ignore(customer => customer.CustomerRoles);

            base.Configure(builder);
        }
    }
}
