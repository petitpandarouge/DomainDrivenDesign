using DomainDrivenDesign.Domain.Entities.MessageAggregate;

namespace DomainDrivenDesign.Application.Infrastructure;

public interface IMessageRepository
{
    Message Get(Guid id);
    void Insert(Message message);
    void UpdateEtat(Guid id, Etat etat);
}