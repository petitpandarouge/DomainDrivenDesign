using DomainDrivenDesign.Application.Dtos;

namespace DomainDrivenDesign.Application.Services;

public interface IMessageService
{
    void Create(MessageCreateDto messageCreateDto);
    void Valider(Guid id);
}