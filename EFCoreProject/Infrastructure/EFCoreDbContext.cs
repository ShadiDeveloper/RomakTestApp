using EFCoreProject.Infrastructure.Configurations;
using EFCoreProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProject.Infrastructure
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new AddressConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
