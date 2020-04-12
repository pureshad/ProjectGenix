using Genix.Core.Domain.Shipping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Shipping
{
    public class ShipmentMap : GenixEntityTypeConfiguration<Shipment>
    {
        public override void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable(nameof(Shipment));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.TrackingNumber).HasMaxLength(400).IsRequired();
            builder.Property(w => w.DeliveryDateUtc);
            builder.Property(w => w.CreatedOnUtc);
            builder.Property(w => w.ShippedDateUtc);

            builder.HasOne(w => w.Order).WithMany(w => w.Shipments).HasForeignKey(w => w.OrderId)
                .IsRequired();


            base.Configure(builder);
        }
    }
}
