using DomainDrivenDesign.Application.Dtos;

namespace DomainDrivenDesign.Application.Services;

public interface IMessageService
{
    // TODO : Should return an ID
    void Create(MessageCreateDto messageCreateDto);
    void Delete(Guid id);
    void Valider(Guid id);
}