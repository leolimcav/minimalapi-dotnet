using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MinimalAPI.Delivery.Entities;

public sealed class Package
{
    public Package() {}

    public Package(int packageId, string code)
    {
        PackageId = packageId;
        Code = code;
    }
    
    [Key]
    [Required]
    public int Id { get; set; }

    public int PackageId { get; set; }

    public string Code { get; set; } = string.Empty;

    [JsonIgnore]
    public List<Location>? Locations { get; set; }
}
