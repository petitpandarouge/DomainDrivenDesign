namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public partial class Message
{
    private readonly IEtatCommands _etatBrouillon;
    private readonly IEtatCommands _etatPublie;
    private IEtatCommands _etat;

    public Message(string titre, string description, IEnumerable<string> tags, DateTime now)
    {
        Titre = titre;
        Description = description;
        Tags = tags.ToList().AsReadOnly();
        CreationDate = now;

        _etatBrouillon = new Brouillon(this);
        _etatPublie = new Publie(this);
        _etat = _etatBrouillon;
    }

    public string Titre { get; }
    public string Description { get; }
    public IReadOnlyCollection<string> Tags { get; }
    public DateTime CreationDate { get; }
    public Etat Etat => _etat.AsEnum();

    public void Valider()
    {
        _etat.Valider();
    }
}
