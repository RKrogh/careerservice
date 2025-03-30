using System.Text.Json.Serialization;

namespace Domain;

public record class Location
{
    [JsonIgnore]
    public int Id { get; init; }
    public required string City { get; init; }
    public required string Country { get; init; }
}
