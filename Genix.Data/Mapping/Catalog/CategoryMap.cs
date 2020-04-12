using Genix.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Catalog
{
    public class CategoryMap : GenixEntityTypeConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name).HasMaxLength(200).IsRequired();
            builder.Property(w => w.Description).HasMaxLength(500);

            base.Configure(builder);
        }
    }
}
