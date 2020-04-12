using Genix.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Genix.Data.Mapping.Common
{
    public class AddressMap : GenixEntityTypeConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.FirstName).HasMaxLength(400);
            builder.Property(w => w.LastName).HasDefaultValue(400);
            builder.Property(w => w.Email).HasMaxLength(400).IsRequired();
            builder.Property(w => w.City).HasMaxLength(100);
            builder.Property(w => w.Address1).HasMaxLength(100);
            builder.Property(w => w.Address2).HasMaxLength(100);
            builder.Property(w => w.PhoneNumber).HasMaxLength(50);
            builder.Property(w => w.CreatedOn);

            builder.HasOne(w => w.Country)
                .WithMany()
                .HasForeignKey(w => w.CountryId)
                .IsRequired();

            builder.HasOne(w => w.StateProvince)
                .WithMany()
                .HasForeignKey(w => w.StateProvinceId)
                .IsRequired().
                OnDelete(DeleteBehavior.NoAction);

            base.Configure(builder);
        }
    }
}
