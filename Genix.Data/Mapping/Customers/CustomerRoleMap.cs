using Genix.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Customers
{
    public class CustomerRoleMap : GenixEntityTypeConfiguration<CustomerRole>
    {
        public override void Configure(EntityTypeBuilder<CustomerRole> builder)
        {
            builder.ToTable(nameof(CustomerRole));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name).HasMaxLength(255).IsRequired();

            base.Configure(builder);
        }
    }
}
