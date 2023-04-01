using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.Delivery.Endpoints;

public sealed class GetPackageHistoryEndpoint : Endpoint<PackageHistoryRequest, List<Location>>
{
  private readonly DeliveryDbContext _db;

  public override void Configure()
  {
    Get("/delivery/packageId/history");
    AllowAnonymous();
  }

  public GetPackageHistoryEndpoint(DeliveryDbContext db)
  {
    _db = db;
  }
  
  public override async Task HandleAsync(PackageHistoryRequest req, CancellationToken ct)
  {
    var history = await _db.Locations
    .Where(l => l.PackageId == req.packageId)
    .OrderByDescending(x => x.Id)
    .ToListAsync(ct)
    .ConfigureAwait(false);

    await SendAsync(history, 200, ct);
  }
}