namespace MinimalAPI.Package.Dto;

public sealed record RegisterPackageDto(int? PackageId, string Code, string Country, string Description);
