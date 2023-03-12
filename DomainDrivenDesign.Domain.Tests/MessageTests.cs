namespace DomainDrivenDesign.Domain.Tests;

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
        message.Titre.Should().Be(titre);
        message.Description.Should().Be(description);
        message.Tags.Should().Equal(tags);
        message.CreationDate.Should().Be(now);
        message.Etat.Should().Be(Etat.Brouillon);
    }

    [Theory, AutoData]
    public void Given_a_message_brouillon_When_I_validate_it_Then_it_is_published
        (string titre, string description, IEnumerable<string> tags, DateTime now)
    {
        // Arrange
        Message message = new(titre, description, tags, now);

        // Act
        message.Valider();

        // Assert
        message.Etat.Should().Be(Etat.Publie);
    }
}