namespace DomainDrivenDesign.Application.Dtos;

public record MessageCreateDto
{
    public string Titre { get; init; } = default!;
    public string Description { get; init; } = default!;
    public IEnumerable<string> Tags { get; init; } = default!;
}