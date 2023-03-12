using System.Diagnostics;
using DomainDrivenDesign.Domain.Core;

namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

[DebuggerDisplay("{Value}")]
public class Titre : ValueObject
{
    public const string MORE_THAN_50_CHAR_ERROR_MSG = "Le titre ne doit pas faire plus de 50 caractères.";

    public Titre(string titre)
    {
        titre = titre ?? throw new ArgumentNullException(nameof(titre));
        if (titre.Length > 50)
        {
            throw new InvalidOperationException(MORE_THAN_50_CHAR_ERROR_MSG);
        }

        Value = titre;
    }

    public string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(Titre titre) => titre.Value;
    public static implicit operator Titre(string titre) => new(titre);
}
