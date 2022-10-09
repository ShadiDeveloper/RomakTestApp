using AuthProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthProject.EF.Configurations
{
    public class UserConfig: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(item => item.Id);

            #region property
            builder.Property(item => item.UserName).HasColumnType("varchar(10)").IsRequired();
            builder.Property(item => item.Password).HasColumnType("varchar(10)").IsRequired();
            #endregion

            #region relation
            builder.HasOne(item => item.Role)
                   .WithOne(item => item.User)
                   .HasForeignKey<User>(item => item.RoleId);
            #endregion

            #region data

            builder.HasData(new User()
            {
                Id=Guid.NewGuid(),
                UserName = "Admin",
                Password = "Admin@123",
                RoleId = Guid.Parse("0F7AA8ED-F39C-45A7-B0A7-0362C4F40FF4"),
            });

            builder.HasData(new User()
            {
                Id = Guid.NewGuid(),
                UserName = "User",
                Password = "User@123",
                RoleId = Guid.Parse("F7AC39B4-B3B6-41C6-8C26-B774E37BA568"),
            });
            #endregion
        }

    }
}
