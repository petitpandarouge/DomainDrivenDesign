namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public class Message
{
    public string Titre { get; }
    public string Description { get; }
    public IEnumerable<string> Tags { get; }
    //public DateTimeOffset CreationDate { get; }

    // https://enterprisecraftsmanship.com/posts/domain-model-purity-current-time/
    public Message(string titre, string description, IEnumerable<string> tags/*, DateTimeOffset now*/)
    {
        Titre = titre;
        Description = description;
        Tags = tags;
    }
}
