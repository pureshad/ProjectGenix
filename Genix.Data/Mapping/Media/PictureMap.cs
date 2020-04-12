using Genix.Core.Domain.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Media
{
    public class PictureMap : GenixEntityTypeConfiguration<Picture>
    {
        public override void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable(nameof(Picture));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.MimeType).HasMaxLength(int.MaxValue).IsRequired();
            builder.Property(w => w.SeaFilename).HasMaxLength(int.MaxValue);
            builder.Property(w => w.AltAttribute).HasMaxLength(int.MaxValue);
            builder.Property(w => w.TitleAttribute).HasMaxLength(int.MaxValue);
            builder.Property(w => w.VirtualPath).HasMaxLength(int.MaxValue);

            base.Configure(builder);
        }
    }
}
