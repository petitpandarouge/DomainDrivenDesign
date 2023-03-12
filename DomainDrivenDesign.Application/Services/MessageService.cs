using DomainDrivenDesign.Application.Dtos;
using DomainDrivenDesign.Application.Infrastructure;
using DomainDrivenDesign.Domain.Entities.MessageAggregate;

namespace DomainDrivenDesign.Application.Services;

public class MessageService : IMessageService
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMessageRepository _messageRepository;

    public MessageService(IDateTimeProvider dateTimeProvider, IMessageRepository messageRepository)
    {
        _dateTimeProvider = dateTimeProvider;
        _messageRepository = messageRepository;
    }

    public void Create(MessageCreateDto messageCreateDto)
    {
        var message = new Message(messageCreateDto.Titre, messageCreateDto.Description, messageCreateDto.Tags, _dateTimeProvider.Now());
        _messageRepository.Insert(message);
    }

    public void Delete(Guid id)
    {
        var message = _messageRepository.Get(id);
        var idToDelete = message.Delete();
        _messageRepository.Delete(idToDelete);
    }

    public void Valider(Guid id)
    {
        var message = _messageRepository.Get(id);
        message.Valider();
        _messageRepository.UpdateEtat(message.Id, message.Etat);
    }
}