namespace DomainDrivenDesign.Domain.Tests.Entities.MessageAggregate;

public class MessageTests
{
    [Theory, AutoData]
    public void When_I_create_a_message_Then_it_should_be_correctly_initialized
        (string titre, string description, IEnumerable<string> tags, DateTime now)
    {
        // Arrange
        // Nothing to do.

        // Act
        Message message = new(titre, description, tags, now);

        // Assert
        message.Titre.Should().Be((Titre)titre);
        message.Description.Should().Be(description);
        message.Tags.Should().Equal(tags);
        message.CreationDate.Should().Be(now);
        message.Etat.Should().Be(Etat.Brouillon);
    }

    [Theory, AutoData]
    public void Given_a_message_brouillon_When_I_valide_it_Then_its_etat_is_publie
        (string titre, string description, IEnumerable<string> tags, DateTime now)
    {
        // Arrange
        Message message = MessageFactory.CreateIdentifiedBrouillon(titre, description, tags, now);

        // Act
        message.Valider();

        // Assert
        message.Etat.Should().Be(Etat.Publie);
    }

    [Theory, AutoData]
    public void Given_a_message_brouillon_When_I_update_its_titre_or_description_Then_modifications_are_taken_in_account
        (string titre, string description, IEnumerable<string> tags, DateTime now, string newTitre, string newDescription)
    {
        // Arrange
        Message message = MessageFactory.CreateIdentifiedBrouillon(titre, description, tags, now);

        // Act
        message.Titre = newTitre;
        message.Description = newDescription;

        // Assert
        message.Titre.Should().Be((Titre)newTitre);
        message.Description.Should().Be((Titre)newDescription);
    }

    [Theory, AutoData]
    public void Given_a_message_publie_When_I_update_its_titre_Then_should_throw_exception
        (string titre, string description, IEnumerable<string> tags, DateTime now, string newTitre)
    {
        // Arrange
        Message message = MessageFactory.CreateIdentifiedMessagePublie(titre, description, tags, now);

        // Act
        var act = () => message.Titre = newTitre;

        // Assert
        act
            .Should()
            .ThrowExactly<InvalidOperationException>()
            .WithMessage("Le message est publié, il ne peut plus être modifié.");
    }
}