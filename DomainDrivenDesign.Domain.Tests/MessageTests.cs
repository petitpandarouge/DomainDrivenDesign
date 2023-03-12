namespace DomainDrivenDesign.Domain.Tests;

public class MessageTests
{
    [Fact]
    public void When_I_create_a_message_Then_it_should_be_correctly_initialized()
    {
        // Arrange
        Fixture fixture = new();
        string titre = fixture.Create<string>();
        string description = fixture.Create<string>();
        IEnumerable<string> tags = fixture.CreateMany<string>();
        DateTime now = fixture.Create<DateTime>();
        Etat etat = Etat.Brouillon;

        // Act
        Message message = new(titre, description, tags, now);

        // Assert
        message.Titre.Should().Be(titre);
        message.Description.Should().Be(description);
        message.Tags.Should().Equal(tags);
        message.CreationDate.Should().Be(now);
        message.Etat.Should().Be(etat);
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