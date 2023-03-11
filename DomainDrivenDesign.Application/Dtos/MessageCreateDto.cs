namespace DomainDrivenDesign.Application.Dtos;

public class MessageCreateDto
{
    public string Titre { get; set; }
    public string Description { get; set; }
    public IEnumerable<string> Tags { get; set; }
}