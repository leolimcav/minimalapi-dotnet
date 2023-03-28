using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Delivery.Module;

public sealed class DeliveryModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/delivery/{packageId}/history", async ([FromServices]DeliveryDbContext db, [FromRoute] int packageId) => 
        {
            var history = await db.Locations.Where(l => l.Id == packageId).OrderByDescending(x => x.Id).ToListAsync();

           return Results.Ok(history);
        });

        app.MapPost("/delivery", async ([FromServices]DeliveryDbContext db, [FromBody] PackageLocation dto) => 
        {
           var entity = db.Locations.Add(new Location
           {
             Id = dto.Id,
             Latitude = dto.Latitude,
             Longitude = dto.Longitude,
           }); 

           await db.SaveChangesAsync();

           return Results.Created($"/delivery/{entity.Entity.Id}", entity.Entity);
        });
    }
}
