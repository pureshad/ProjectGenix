using Genix.Core.Domain.Shipping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Shipping
{
    public class ShippingMethodMap : GenixEntityTypeConfiguration<ShippingMethod>
    {
        public override void Configure(EntityTypeBuilder<ShippingMethod> builder)
        {
            builder.ToTable(nameof(ShippingMethod));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name).HasMaxLength(200).IsRequired();
            builder.Property(w => w.Description).HasMaxLength(200);

            base.Configure(builder);
        }
    }
}
