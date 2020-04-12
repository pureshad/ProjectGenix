using Genix.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Catalog
{
    public class ProductCategoryMap : GenixEntityTypeConfiguration<ProductCategory>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("Product_Category_Mapping");

            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Category).WithMany()
                .HasForeignKey(w => w.CategoryId)
                .IsRequired();

            builder.HasOne(w => w.Product).WithMany()
                .HasForeignKey(w => w.ProductId).IsRequired();
            base.Configure(builder);

        }
    }
}
