using Data.Context.Configuration;
using Data.DataSources;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DatabaseContext: DbContext
    {
        public DbSet<ClientDataSource> Clients { get; set; }
        public DbSet<IceCreamDataSource> IceCreams { get; set; }
        public DbSet<OrderDataSource> Orders { get; set; }
        public DbSet<CompositionDataSource> Compositions { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}