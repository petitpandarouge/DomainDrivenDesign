namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public partial class Message
{
    private readonly Brouillon _etatBrouillon;
    private readonly Publie _etatPublie;
    private readonly Deleting _etatDeleting;
    private IEtatCommands _etat;

    private Titre _titre = default!;

    // TODO : Transformer DateTime en DateTimeOffset
    /// <summary>
    /// See: https://enterprisecraftsmanship.com/posts/domain-model-purity-current-time/
    /// </summary>
    public Message(Titre titre, string description, IEnumerable<string> tags, DateTime now)
    {
        _etatBrouillon = new (this);
        _etatPublie = new (this);
        _etatDeleting = new (this);
        _etat = _etatBrouillon;

        Titre = titre;
        Description = description;
        Tags = tags.ToList().AsReadOnly();
        CreationDate = now;
    }

    // TODO : Ne permettre le set que si id est empty et Guid => class Id
    public Guid Id { get; set; }

    public Titre Titre 
    { 
        get
        {
            return _titre;
        }
        set
        {
            _etat.SetTitre(value);
        }
    }

    public string Description { get; set; }
    /// <summary>
    /// See : https://enterprisecraftsmanship.com/posts/which-collection-interface-to-use/
    /// </summary>
    public IReadOnlyCollection<string> Tags { get; }
    public DateTime CreationDate { get; }
    public Etat Etat => _etat.AsEnum();

    public void Valider()
    {
        _etat.Valider();
    }

    public Guid Delete()
    {
        var id = Id;
        _etat.Delete();
        return id;
    }
}
