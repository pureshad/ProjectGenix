using Genix.Core.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Orders
{
    public class OrderMap : GenixEntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.OrderGuid).HasMaxLength(int.MaxValue).IsRequired();
            builder.Property(w => w.ShippingMethod);
            builder.Property(w => w.Deleted);
            builder.Property(w => w.OrderTotal).HasColumnType("decimal(18, 4)");
            builder.Property(w => w.CreatedOnUtc);
            builder.Property(w => w.PaidDateUtc);

            builder.HasOne(w => w.Customer).WithMany().HasForeignKey(w => w.CustomerId)
                .IsRequired();

            builder.HasOne(w => w.BillingAddress).WithMany()
                .HasForeignKey(w => w.BillingAddressId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(w => w.PickupAddress).WithMany().HasForeignKey(w => w.PickupAddressId)
                .IsRequired();

            builder.Ignore(w => w.ShippingStatus);
            builder.Ignore(w => w.OrderStatus);
            builder.Ignore(w => w.PaymentStatus);

            base.Configure(builder);
        }
    }
}
