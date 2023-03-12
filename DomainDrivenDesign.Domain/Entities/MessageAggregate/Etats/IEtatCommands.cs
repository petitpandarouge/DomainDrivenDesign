namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public interface IEtatCommands
{
    Etat AsEnum();
    void Delete();
    void SetTitre(Titre titre);
    void Valider();
}
