using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.Delivery.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddEfCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DeliveryDbContext>(opt => 
                opt.UseNpgsql(configuration.GetConnectionString("DbConn")));

        return services;
    }

    public static async Task<IApplicationBuilder> MigrateDatabase(this IApplicationBuilder app)
    {
        using (var db = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DeliveryDbContext>())
        {
            await db.Database.MigrateAsync();
        }

        return app;
    }
}
