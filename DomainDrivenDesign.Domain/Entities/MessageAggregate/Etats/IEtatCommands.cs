namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public interface IEtatCommands
{
    Etat AsEnum();

    void Valider();
}
