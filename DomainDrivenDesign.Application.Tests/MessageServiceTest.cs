namespace DomainDrivenDesign.Application.Tests;

public class MessageServiceTest
{
    [Theory, AutoData]
    public void When_I_create_a_message_Then_it_is_persisted_with_its_creation_date_as_brouillon
        (MessageCreateDto messageCreateDto, DateTime now)
    {
        // Arrange
        Mock<IDateTimeProvider> dateTimeProviderMock = new();
        dateTimeProviderMock.Setup(x => x.Now()).Returns(now);
        IDateTimeProvider dateTimeProvider = dateTimeProviderMock.Object;

        Mock<IMessageRepository> messageRepositoryMock = new();
        messageRepositoryMock.Setup(x => x.Insert(It.IsAny<Message>()));
        IMessageRepository messageRepository = messageRepositoryMock.Object;

        IMessageService service = new MessageService(dateTimeProvider, messageRepository);

        // Act
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
                    m.Etat == Etat.Brouillon)),
            Times.Once);
    }

    [Theory, AutoData]
    public void Given_a_message_brouillon_When_I_valide_Then_the_message_is_publie
        (string titre, string description, IEnumerable<string> tags, DateTime now)
    {
        // Arrange
        Mock<IDateTimeProvider> dateTimeProviderMock = new();
        IDateTimeProvider dateTimeProvider = dateTimeProviderMock.Object;

        var message = MessageFactory.CreateIdentifiedBrouillon(titre, description, tags, now);

        Mock<IMessageRepository> messageRepositoryMock = new();
        messageRepositoryMock.Setup(x => x.Get(message.Id)).Returns(message);
        IMessageRepository messageRepository = messageRepositoryMock.Object;

        IMessageService service = new MessageService(dateTimeProvider, messageRepository);

        // Act
        service.Valider(message.Id);

        // Assert
        messageRepositoryMock.Verify(
            r => r.Get(message.Id),
            Times.Once);
        messageRepositoryMock.Verify(
            r => r.UpdateEtat(message.Id, Etat.Publie),
            Times.Once);
    }

    [Theory, AutoData]
    public void Given_a_message_brouillon_When_I_delete_it_Then_the_message_cannot_be_recovered
        (string titre, string description, IEnumerable<string> tags, DateTime now)
    {
        // Arrange
        Mock<IDateTimeProvider> dateTimeProviderMock = new();
        IDateTimeProvider dateTimeProvider = dateTimeProviderMock.Object;

        var message = MessageFactory.CreateIdentifiedBrouillon(titre, description, tags, now);
        // The message id is erased by the delete method.
        var idMessage = message.Id;

        Mock<IMessageRepository> messageRepositoryMock = new();
        messageRepositoryMock.Setup(x => x.Get(message.Id)).Returns(message);
        IMessageRepository messageRepository = messageRepositoryMock.Object;

        IMessageService service = new MessageService(dateTimeProvider, messageRepository);
        

        // Act
        service.Delete(idMessage);

        // Assert
        messageRepositoryMock.Verify(
            r => r.Get(idMessage),
            Times.Once);
        messageRepositoryMock.Verify(
            r => r.Delete(idMessage),
            Times.Once);
    }
}