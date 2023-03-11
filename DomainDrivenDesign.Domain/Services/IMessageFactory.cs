using DomainDrivenDesign.Domain.Entities;

namespace DomainDrivenDesign.Domain.Services;

public interface IMessageFactory
{
    Message Create(string titre, string description, IEnumerable<string> tags);
}