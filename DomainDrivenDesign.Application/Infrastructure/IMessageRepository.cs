using DomainDrivenDesign.Domain.Entities.MessageAggregate;

namespace DomainDrivenDesign.Application.Infrastructure;

public interface IMessageRepository
{
    void Insert(Message message);
}