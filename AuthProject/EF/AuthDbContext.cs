using AuthProject.EF.Configurations;
using AuthProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthProject.EF
{
    public class AuthDbContext:DbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
