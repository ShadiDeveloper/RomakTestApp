using CQRS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.Infrastructure.Configurations
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {

            builder.ToTable("Addresses").HasKey(item => item.Id);

            #region property
            builder.Property(item => item.City).HasMaxLength(150).IsRequired();
            builder.Property(item => item.Street).HasMaxLength(150).IsRequired();
            #endregion

            #region relation
            builder.HasOne(item => item.Person)
                   .WithMany(item => item.Addresses)
                   .HasForeignKey(item => item.PersonId);
            #endregion

        }
    }
}
