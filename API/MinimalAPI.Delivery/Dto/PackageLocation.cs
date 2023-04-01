namespace MinimalAPI.Delivery.Dto;

public sealed record PackageLocation(int Id, string Code, string Latitude, string Longitude);

public sealed class PackageLocationRequest 
{
  public int Id { get; set; }

  public string Code { get; set; } = string.Empty;

  public string Latitude { get; set; } = string.Empty;

  public string Longitude { get; set; } = string.Empty;
}

public sealed class PackageLocationResponse 
{
  public int Id { get; set; }

  public string Code { get; set; } = string.Empty;

  public string Latitude { get; set; } = string.Empty;

  public string Longitude { get; set; } = string.Empty;
}

public sealed class PackageHistoryRequest
{
  public int packageId { get; set; }
}
