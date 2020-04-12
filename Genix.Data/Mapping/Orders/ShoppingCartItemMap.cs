using Genix.Core.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Orders
{
    public class ShoppingCartItemMap : GenixEntityTypeConfiguration<ShoppingCartItem>
    {
        public override void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.ToTable(nameof(ShoppingCartItem));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Quantity);
            builder.Property(w => w.CreatedOn);
            builder.Property(w => w.UpdatedOn);

            builder.HasOne(w => w.Product)
                .WithMany()
                .HasForeignKey(w => w.ProductId)
                .IsRequired();

            builder.HasOne(w => w.Customer)
                .WithMany(w => w.ShoppingCartItems)
                .HasForeignKey(w => w.CustomerId)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
