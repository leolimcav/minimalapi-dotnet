using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.Delivery.Context;

public sealed class DeliveryDbContext : DbContext
{
   public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options) { } 

   public DbSet<Location> Locations => Set<Location>();
}
