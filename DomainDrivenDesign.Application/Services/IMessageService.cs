using DomainDrivenDesign.Application.Dtos;

namespace DomainDrivenDesign.Application.Services;

public interface IMessageService
{
    // TODO : Should return an ID
    void Create(MessageCreateDto messageCreateDto);
    void Valider(Guid id);
}