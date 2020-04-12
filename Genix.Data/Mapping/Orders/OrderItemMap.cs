using Genix.Core.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Orders
{
    public class OrderItemMap : GenixEntityTypeConfiguration<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable(nameof(OrderItem));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Quantity);
            builder.Property(w => w.Price).HasColumnName("decimal(18, 4)");

            builder.HasOne(w => w.Product).WithMany()
                .HasForeignKey(w => w.ProductId).IsRequired();

            builder.HasOne(w => w.Order).WithMany(w => w.OrderItems)
                .HasForeignKey(w => w.OrderId).IsRequired();


            base.Configure(builder);
        }
    }
}
