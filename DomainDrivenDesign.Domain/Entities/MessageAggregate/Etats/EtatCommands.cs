namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public abstract class EtatCommands : IEtatCommands
{
    protected EtatCommands(Message message)
    {
        Message = message;
    }

    protected Message Message { get; }

    public abstract Etat AsEnum();
    public abstract void SetTitre(Titre titre);
    public abstract void Valider();
}
