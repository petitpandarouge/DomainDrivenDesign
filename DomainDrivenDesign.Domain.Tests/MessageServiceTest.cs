namespace DomainDrivenDesign.Domain.Tests;

public class MessageServiceTest
{
    [Fact]
    public void When_I_create_a_message_Then_it_should_be_correctly_initialized()
    {
        // Arrange
        IMessageFactory factory = new MessageFactory();
        Fixture fixture = new();
        string titre = fixture.Create<string>();
        string description = fixture.Create<string>();
        IEnumerable<string> tags = fixture.CreateMany<string>();

        // Act
        Message message = factory.Create(titre, description, tags);

        // Assert
        message.Titre.Should().Be(titre);
        message.Description.Should().Be(description);
        message.Tags.Should().Equal(tags);
    }
}