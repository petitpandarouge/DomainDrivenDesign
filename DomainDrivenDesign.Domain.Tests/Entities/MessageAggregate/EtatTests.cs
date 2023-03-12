namespace DomainDrivenDesign.Domain.Tests.Entities.MessageAggregate;

public class EtatTests : IClassFixture<EtatFixture>
{
    private readonly EtatFixture _fixture;

    public EtatTests(EtatFixture fixture)
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
            .WithMessage(EtatCommands.ONLY_BROUILLON_CAN_BE_VALIDE_ERROR_MSG);
    }

    [Theory, AutoData]
    public void Given_a_etat_brouillon_When_I_update_the_titre_Then_the_modification_is_taken_into_account(string titre)
    {
        // Arrange
        // Nothing to do.

        // Act
        _fixture.EtatBrouillon.SetTitre(titre);

        // Assert
        _fixture.Message.Titre.Should().Be((Titre)titre);
    }

    [Theory, AutoData]
    public void Given_a_etat_publie_When_I_update_the_titre_Then_should_throw_exception(string titre)
    {
        // Arrange
        // Nothing to do.

        // Act
        var act = () => _fixture.EtatPublie.SetTitre(titre);

        // Assert
        act
            .Should()
            .ThrowExactly<InvalidOperationException>()
            .WithMessage(Message.Publie.MSG_CANNOT_BE_MODIFIED_ERROR_MSG);
    }
}