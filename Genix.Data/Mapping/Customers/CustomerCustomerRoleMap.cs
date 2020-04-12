using Genix.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Customers
{
    public class CustomerCustomerRoleMap : GenixEntityTypeConfiguration<CustomerCustomerRoleMapping>
    {
        public override void Configure(EntityTypeBuilder<CustomerCustomerRoleMapping> builder)
        {
            builder.ToTable("Customer_CustomerRole_Mapping");
            builder.HasKey(mapping => new { mapping.CustomerId, mapping.CustomerRoleId });

            builder.Property(property => property.CustomerId).HasColumnName("Customer_Id");
            builder.Property(property => property.CustomerRoleId).HasColumnName("CustomerRole_Id");

            builder.HasOne(mapping => mapping.Customer)
                .WithMany(customer => customer.CustomerCustomerRoleMappings).
                HasForeignKey(map => map.CustomerId).IsRequired();

            builder.HasOne(w => w.CustomerRole).WithMany()
                .HasForeignKey(w => w.CustomerRoleId).IsRequired();

            builder.Ignore(w => w.Id);

            base.Configure(builder);
        }
    }
}
