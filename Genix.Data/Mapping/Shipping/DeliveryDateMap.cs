using Genix.Core.Domain.Shipping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Shipping
{
    public class DeliveryDateMap : GenixEntityTypeConfiguration<DeliveryDate>
    {
        public override void Configure(EntityTypeBuilder<DeliveryDate> builder)
        {
            builder.ToTable(nameof(DeliveryDate));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name).HasMaxLength(100).IsRequired();

            base.Configure(builder);
        }
    }
}
