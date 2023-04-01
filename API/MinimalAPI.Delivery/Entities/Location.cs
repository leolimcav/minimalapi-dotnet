using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MinimalAPI.Delivery.Entities;

public sealed class Location
{
    [Key]
    [Required]
    public int Id { get; set; }

    [ForeignKey(nameof(PackageId))]
    public int PackageId { get; set; }

    [Required]
    public string Latitude { get; set; } = string.Empty;

    [Required]
    public string Longitude { get; set; } = string.Empty;

    [JsonIgnore]
    public Package Package { get; set; }
}
