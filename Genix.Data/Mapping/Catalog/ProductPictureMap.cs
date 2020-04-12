using Genix.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Catalog
{
    public class ProductPictureMap : GenixEntityTypeConfiguration<ProductPicture>
    {
        public override void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("Product_Picture_Mapping");

            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Product).WithMany()
                .HasForeignKey(w => w.ProductId)
                .IsRequired();

            builder.HasOne(w => w.Picture).WithMany()
                .HasForeignKey(w => w.PictureId)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
