using Genix.Core.Domain.Shipping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Shipping
{
    public class ShipmentItemMap : GenixEntityTypeConfiguration<ShipmentItem>
    {
        public override void Configure(EntityTypeBuilder<ShipmentItem> builder)
        {
            builder.ToTable(nameof(ShipmentItem));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Quantity);

            builder.HasOne(w => w.Shipment).WithMany(w => w.ShipmentItems)
                .HasForeignKey(w => w.ShipmentId).IsRequired();

            base.Configure(builder);
        }
    }
}
