using CQRS.Domain.Models.Entities;
using CQRS.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Infrastructure
{
    public class CqrsDbContext : DbContext
    {
        public CqrsDbContext(DbContextOptions options) : base(options)
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
