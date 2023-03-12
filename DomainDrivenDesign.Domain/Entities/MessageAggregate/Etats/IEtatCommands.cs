namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public interface IEtatCommands
{
    Etat AsEnum();
    void SetTitre(Titre titre);
    void Valider();
}
