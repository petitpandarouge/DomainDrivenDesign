using DomainDrivenDesign.Domain.Core;

namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public class Titre : ValueObject
{
    public Titre(string titre)
    {
        Value = titre ?? throw new ArgumentNullException(nameof(titre));
    }

    public string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(Titre titre) => titre.Value;
    public static implicit operator Titre(string titre) => new(titre);
}
