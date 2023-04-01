using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.Delivery.Endpoints;

[HttpPost("/delivery"), AllowAnonymous]
public sealed class CreatePackageEndpoint : Endpoint<PackageLocationRequest, PackageLocationResponse>
{
  private readonly DeliveryDbContext? _db;

  public CreatePackageEndpoint(DeliveryDbContext db)
  {
    _db = db;
  }

  public override async Task HandleAsync(PackageLocationRequest req, CancellationToken ct)
  {
    var package = await _db!.Packages.Where(x => x.Code == req.Code).FirstOrDefaultAsync();

    if(package is not null)
    {
        var entity = _db.Locations.Add(new Location
        {
          Id = req.Id,
          PackageId = package.PackageId,
          Latitude = req.Latitude,
          Longitude = req.Longitude,
        }); 

        await _db.SaveChangesAsync();
    }

    var response = new PackageLocationResponse 
    {
      Id = req.Id,
      Code = req.Code,
      Latitude = req.Latitude,
      Longitude = req.Longitude,
    };

    await SendAsync(response, 201, ct);
  }
}