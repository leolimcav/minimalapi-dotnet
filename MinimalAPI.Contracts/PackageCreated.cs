namespace MinimalAPI.Contracts;

public sealed class PackageCreated
{
    public int PackageId { get; set; }

    public string Code { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; }
}
