namespace DomainDrivenDesign.Domain.Tests;

public class EtatMessageTests : IClassFixture<EtatMessageFixture>
{
    private readonly EtatMessageFixture _fixture;

    public EtatMessageTests(EtatMessageFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Given_a_etat_brouillon_When_I_valide_Then_the_current_etat_is_publie()
    {
        // Arrange
        // Nothing to do.

        // Act
        _fixture.EtatBrouillon.Valider();

        // Assert
        _fixture.Message.Etat.Should().Be(Etat.Publie);
    }

    [Fact]
    public void Given_a_etat_publie_When_I_valide_Then_should_throw_exception()
    {
        // Arrange
        // Nothing to do.

        // Act
        var act = () => _fixture.EtatPublie.Valider();

        // Assert
        act
            .Should()
            .ThrowExactly<InvalidOperationException>()
            .WithMessage("Seul un brouillon peut être validé.");
    }
}