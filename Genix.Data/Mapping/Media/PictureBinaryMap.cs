using Genix.Core.Domain.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Media
{
    public class PictureBinaryMap : GenixEntityTypeConfiguration<PictureBinary>
    {
        public override void Configure(EntityTypeBuilder<PictureBinary> builder)
        {
            builder.ToTable(nameof(PictureBinary));
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Picture)
                .WithOne(w => w.PictureBinary)
                .HasForeignKey<PictureBinary>(w => w.PictureId)
                .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
