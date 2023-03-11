using DomainDrivenDesign.Application.Dtos;
using DomainDrivenDesign.Application.Infrastructure;

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
        throw new NotImplementedException();
    }
}