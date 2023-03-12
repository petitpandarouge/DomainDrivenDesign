using AutoFixture;

namespace DomainDrivenDesign.Application.Tests.Factories;

internal static class MessageFactory
{
    public static Message CreateIdentifiedBrouillon(string titre, string description, IEnumerable<string> tags, DateTime now)
    {
        return new Message(titre, description, tags, now)
        {
            Id = Guid.NewGuid(),
        };
    }

    public static Message CreateIdentifiedMessagePublie(string titre, string description, IEnumerable<string> tags, DateTime now)
    {
        var message = CreateIdentifiedBrouillon(titre, description, tags, now);
        message.Valider();
        return message;
    }
}
