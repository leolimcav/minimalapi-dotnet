using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.Delivery.Context;

public sealed class DeliveryDbContext : DbContext
{
   public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options) { } 

   public DbSet<Location> Locations => Set<Location>();

   public DbSet<Package> Packages => Set<Package>();

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
       modelBuilder.Entity<Location>()
           .HasOne(p => p.Package)
           .WithMany(b => b.Locations)
           .HasPrincipalKey(p => p.PackageId)
           .IsRequired();
   }
}
