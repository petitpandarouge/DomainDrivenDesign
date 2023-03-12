using DomainDrivenDesign.Domain.Entities.MessageAggregate;

namespace DomainDrivenDesign.Application.Infrastructure;

public interface IMessageRepository
{
    void Delete(Guid id);
    Message Get(Guid id);
    void Insert(Message message);
    void UpdateEtat(Guid id, Etat etat);
}