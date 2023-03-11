namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public class Message
{
    public string Titre { get; }
    public string Description { get; }
    public IReadOnlyCollection<string> Tags { get; }

    public Message(string titre, string description, IEnumerable<string> tags)
    {
        Titre = titre;
        Description = description;
        Tags = tags.ToList().AsReadOnly();
    }
}
