using Genix.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Catalog
{
    public class ProductMap : GenixEntityTypeConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            builder.HasKey(w => w.Id);
            builder.Property(w => w.Name).HasMaxLength(400).IsRequired();
            builder.Property(w => w.Sku).HasMaxLength(400);
            builder.Property(w => w.IsShipEnabled);
            builder.Property(w => w.StockQuantity);
            builder.Property(w => w.Price).HasColumnType("decimal(18, 4)");
            builder.Property(w => w.OldPrice).HasColumnType("decimal(18, 4)");
            builder.Property(w => w.Published);
            builder.Property(w => w.CreatedOn).HasColumnType("datetime2");
            builder.Property(w => w.UpdatedOn).HasColumnType("datetime2");

            base.Configure(builder);
        }
    }
}
