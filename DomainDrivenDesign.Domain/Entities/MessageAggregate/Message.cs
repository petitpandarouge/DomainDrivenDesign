﻿namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public partial class Message
{
    private readonly Brouillon _etatBrouillon;
    private readonly Publie _etatPublie;
    private IEtatCommands _etat;

    // TODO : Transformer DateTime en DateTimeOffset
    /// <summary>
    /// See: https://enterprisecraftsmanship.com/posts/domain-model-purity-current-time/
    /// </summary>
    public Message(Titre titre, string description, IEnumerable<string> tags, DateTime now)
    {
        Titre = titre;
        Description = description;
        Tags = tags.ToList().AsReadOnly();
        CreationDate = now;

        _etatBrouillon = new Brouillon(this);
        _etatPublie = new Publie(this);
        _etat = _etatBrouillon;
    }

    // TODO : Ne permettre le set que si id est empty et Guid => class Id
    public Guid Id { get; set; }
    public Titre Titre { get; }
    public string Description { get; }
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
}
