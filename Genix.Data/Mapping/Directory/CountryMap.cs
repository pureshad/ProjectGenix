using Genix.Core.Domain.Directory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Directory
{
    public class CountryMap : GenixEntityTypeConfiguration<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(nameof(Country));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name).HasMaxLength(200).IsRequired();
            builder.Property(w => w.AllowBilling);
            builder.Property(w => w.AllowShipping);
            builder.Property(w => w.TwoLetterIsoCode).HasMaxLength(2);
            builder.Property(w => w.ThreeLetterIsoCode).HasMaxLength(3);
            builder.Property(w => w.NumericIsoCode);

            base.Configure(builder);
        }
    }
}
