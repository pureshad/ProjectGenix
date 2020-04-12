using Genix.Core.Domain.Directory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Directory
{
    public class StateProvinceMap : GenixEntityTypeConfiguration<StateProvince>
    {
        public override void Configure(EntityTypeBuilder<StateProvince> builder)
        {
            builder.ToTable(nameof(StateProvince));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name).HasMaxLength(100).IsRequired();
            builder.Property(w => w.Abbreviation).HasMaxLength(400).IsRequired();

            builder.HasOne(w => w.Country)
                .WithMany(w => w.StateProvinces)
                .HasForeignKey(w => w.CountryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            base.Configure(builder);
        }
    }
}
