using Genix.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Customers
{
    public class CustomerPasswordMap : GenixEntityTypeConfiguration<CustomerPassword>
    {
        public override void Configure(EntityTypeBuilder<CustomerPassword> builder)
        {
            builder.ToTable(nameof(CustomerPassword));
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Customer)
                .WithMany().HasForeignKey(w => w.CustomerId).IsRequired();

            builder.Ignore(w => w.PasswordFormat);

            base.Configure(builder);
        }
    }
}
