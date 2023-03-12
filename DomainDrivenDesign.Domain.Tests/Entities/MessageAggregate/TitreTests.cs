namespace DomainDrivenDesign.Domain.Tests.Entities.MessageAggregate;

public class TitreTests
{
    [Fact]
    public void Given_a_null_titre_When_I_create_it_Then_it_should_throw_an_exception()
    {
        // Arrange
        string? titre = null;

        // Act
#pragma warning disable CS8604 // Possible null reference argument.
        var act = () => new Titre(titre);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert
        act
            .Should()
            .ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void Given_a_titre_of_more_than_50_char_When_I_create_it_Then_it_should_throw_an_exception()
    {
        // Arrange
        string titre = "Mon titre d'une longueur de 51 caractères la la lèr";

        // Act
        var act = () => new Titre(titre);

        // Assert
        act
            .Should()
            .ThrowExactly<InvalidOperationException>()
            .WithMessage(Titre.MORE_THAN_50_CHAR_ERROR_MSG);
    }
}
