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
        EtatMessage etat = EtatMessage.Brouillon;

        // Act
        Message message = new(titre, description, tags, now);

        // Assert
        message.Titre.Should().Be(titre);
        message.Description.Should().Be(description);
        message.Tags.Should().Equal(tags);
        message.CreationDate.Should().Be(now);
        message.Etat.Should().Be(etat);
    }
}