using System.Text.Json.Serialization;

namespace Domain;

public record class CareerEntry
{
    [JsonIgnore]
    public int Id { get; init; }
    public required Guid PublicId { get; init; }
    public required string Title { get; init; }
    public required string CompanyName { get; init; }
    public required int LocationId { get; init; }
    public required Location Location { get; init; }

    public required DateOnly StartingDate { get; init; }
    public DateOnly? EndingDate { get; init; }
    public required string AboutWorkplace { get; init; }
    public required string MyRole { get; init; }

    [JsonIgnore]
    public int? ParentId { get; init; }
    public required CareerEntry? Parent { get; init; }
    public List<CareerTag> Tags { get; } = [];
}
