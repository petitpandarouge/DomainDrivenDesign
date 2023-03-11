namespace DomainDrivenDesign.Domain.Entities;

public class Message
{
    public string Titre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IEnumerable<string> Tags { get; set; } = new List<string>();
}
