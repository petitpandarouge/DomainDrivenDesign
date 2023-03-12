using AutoFixture;

namespace DomainDrivenDesign.Application.Tests.Factories;

internal static class MessageFactory
{
    public static Message CreateBrouillon(string titre, string description, IEnumerable<string> tags, DateTime now)
    {
        return new Message(titre, description, tags, now);
    }

    public static Message CreateMessagePublie(string titre, string description, IEnumerable<string> tags, DateTime now)
    {
        var message = CreateBrouillon(titre, description, tags, now);
        message.Valider();
        return message;
    }
}
