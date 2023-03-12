namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public abstract class AbstractEtatCommands : IEtatCommands
{
    protected AbstractEtatCommands(Message message)
    {
        Message = message;
    }

    protected Message Message { get; }

    public abstract Etat AsEnum();
    public abstract void Valider();
}
