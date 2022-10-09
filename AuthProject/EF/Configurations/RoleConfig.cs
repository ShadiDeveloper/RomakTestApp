using AuthProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthProject.EF.Configurations
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles").HasKey(item => item.Id);
            builder.Property(item => item.Name).HasMaxLength(100).IsRequired();

            #region data

            builder.HasData(new Role()
            {
                Id = Guid.Parse("0F7AA8ED-F39C-45A7-B0A7-0362C4F40FF4"),
                Name = "Admin"
            });

            builder.HasData(new Role()
            {
                Id = Guid.Parse("F7AC39B4-B3B6-41C6-8C26-B774E37BA568"),
                Name = "User"
            });
            #endregion
        }
    }
}
