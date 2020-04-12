using Genix.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Customers
{
    public class CustomerAddressMap : GenixEntityTypeConfiguration<CustomerAddressMapping>
    {
        public override void Configure(EntityTypeBuilder<CustomerAddressMapping> builder)
        {
            builder.ToTable("CustomerAddresses");
            builder.HasKey(w => new { w.CustomerId, w.AddressId });

            builder.Property(w => w.CustomerId).HasColumnName("Customer_Id");
            builder.Property(w => w.AddressId).HasColumnName("Address_Id");

            builder.HasOne(w => w.Customer)
                .WithMany(w => w.CustomerAddressMappings)
                .HasForeignKey(w => w.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(w => w.Address).WithMany()
                .HasForeignKey(w => w.AddressId).IsRequired();

            builder.Ignore(w => w.Id);

            base.Configure(builder);
        }
    }
}
