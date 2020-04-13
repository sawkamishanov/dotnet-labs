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
        
        // N : N
        public DbSet<ActiveOrderDataSource> ActiveOrders { get; set; }
        public DbSet<SelectedCompositionDataSource> SelectedComposition { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Host=localhost;Port=5432;Database=icm;Username=postgres;Password=postgres");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // [Order] -> N: [ActiveOrder] :N <- [IceCream]
            modelBuilder.Entity<ActiveOrderDataSource>()
                .HasKey(k => new {k.OrderId, k.IceCreamId});

            modelBuilder.Entity<ActiveOrderDataSource>()
                .HasOne(sc => sc.IceCream)
                .WithMany(s => s.Orders)
                .HasForeignKey(sc => sc.IceCreamId);

            modelBuilder.Entity<ActiveOrderDataSource>()
                .HasOne(sc => sc.Order)
                .WithMany(s => s.Orders)
                .HasForeignKey(sc => sc.OrderId);
            
            // [IceCream] -> N: [SelectedComposition] :N <- [Composition]
            modelBuilder.Entity<SelectedCompositionDataSource>()
                .HasKey(k => new {k.IceCreamId, k.CompositionId});

            modelBuilder.Entity<SelectedCompositionDataSource>()
                .HasOne(sc => sc.IceCream)
                .WithMany(s => s.Compositions)
                .HasForeignKey(sc => sc.IceCreamId);

            modelBuilder.Entity<SelectedCompositionDataSource>()
                .HasOne(sc => sc.Composition)
                .WithMany(s => s.Compositions)
                .HasForeignKey(sc => sc.CompositionId);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}