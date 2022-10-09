using EFCoreProject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreProject.Infrastructure.Configurations
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons").HasKey(item => item.Id);

            #region property
            builder.Property(item => item.FullName).HasMaxLength(100).IsRequired();
            #endregion
        }
    }
}
