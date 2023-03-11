namespace DomainDrivenDesign.Application.Tests;

public class MessageServiceTest
{
    [Theory, AutoData]
    public void Given_a_message_When_I_create_it_Then_it_is_persisted_with_its_creation_date_as_brouillon(MessageCreateDto messageCreateDto, DateTime now)
    {
        // Arrange
        Mock<IDateTimeProvider> dateTimeProviderMock = new();
        dateTimeProviderMock.Setup(x => x.Now()).Returns(now);
        IDateTimeProvider dateTimeProvider = dateTimeProviderMock.Object;

        Mock<IMessageRepository> messageRepositoryMock = new();
        messageRepositoryMock.Setup(x => x.Insert(It.IsAny<Message>()));
        IMessageRepository messageRepository = messageRepositoryMock.Object;

        // Act
        IMessageService service = new MessageService(dateTimeProvider, messageRepository);
        service.Create(messageCreateDto);

        // Assert
        dateTimeProviderMock.Verify(p => p.Now(), Times.Once);
        messageRepositoryMock.Verify(
                r => r.Insert(It.Is<Message>(
                    m =>
                        m.Titre == messageCreateDto.Titre &&
                        m.Description == messageCreateDto.Description &&
                        m.Tags.SequenceEqual(messageCreateDto.Tags) &&
                        m.CreationDate == now &&
                        m.Etat == EtatMessage.Brouillon)),
                Times.Once);
    }
}