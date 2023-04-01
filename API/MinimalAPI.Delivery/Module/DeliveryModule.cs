using Carter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Delivery.Module;

public sealed class DeliveryModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/delivery/{packageId}/history", async ([FromServices]DeliveryDbContext db, [FromRoute] int packageId) => 
        {
            var history = await db.Locations.Where(l => l.PackageId == packageId).OrderByDescending(x => x.Id).ToListAsync();

            return Results.Ok(history);
        });

        app.MapPost("/delivery", async ([FromServices]DeliveryDbContext db, PackageLocation dto) => 
        {
           var package = await db.Packages.Where(x =>  x.Code == dto.Code).FirstOrDefaultAsync();

           if(package is not null)
           {
               var entity = db.Locations.Add(new Location
               {
                 Id = dto.Id,
                 PackageId = package.PackageId,
                 Latitude = dto.Latitude,
                 Longitude = dto.Longitude,
               }); 

               await db.SaveChangesAsync();
           }
           

           return Results.Created($"/delivery/{dto.Id}", dto);
        });
    }
}
