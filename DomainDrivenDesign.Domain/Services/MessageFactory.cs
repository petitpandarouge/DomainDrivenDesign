using DomainDrivenDesign.Domain.Entities;

namespace DomainDrivenDesign.Domain.Services;
public class MessageFactory : IMessageFactory
{
    public Message Create(string titre, string description, IEnumerable<string> tags) => new()
    {
        Titre = titre,
        Description = description,
        Tags = tags
    };
}