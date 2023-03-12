namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public abstract class EtatCommands : IEtatCommands
{
    public const string ONLY_BROUILLON_CAN_BE_VALIDE_ERROR_MSG = "Seul un brouillon peut être validé.";

    protected EtatCommands(Message message)
    {
        Message = message;
    }

    protected Message Message { get; }

    public abstract Etat AsEnum();
    public abstract void SetTitre(Titre titre);
    public abstract void Valider();
}
