using System.Text.Json.Serialization;

namespace Domain;

public record class CareerTag
{
    [JsonIgnore]
    public int Id { get; init; }
    public required string Name { get; init; }
    public List<CareerEntry> CareerEntries { get; } = [];
}
