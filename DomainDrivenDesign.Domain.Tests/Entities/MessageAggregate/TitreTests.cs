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
}
