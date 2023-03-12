namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public class Titre
{
    private readonly string _titre;

    public Titre(string titre)
    {
        _titre = titre ?? throw new ArgumentNullException(nameof(titre));
    }
}
