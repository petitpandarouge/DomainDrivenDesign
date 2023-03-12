namespace DomainDrivenDesign.Domain.Tests;

public class EtatMessageFixture
{
    public EtatMessageFixture()
    {
        Fixture fixture = new();
        string titre = fixture.Create<string>();
        string description = fixture.Create<string>();
        IEnumerable<string> tags = fixture.CreateMany<string>();
        DateTime now = fixture.Create<DateTime>();

        Message = new(titre, description, tags, now);
        EtatBrouillon = new Message.Brouillon(Message);
        EtatPublie = new Message.Publie(Message);
    }

    public Message Message { get; }
    public Message.Brouillon EtatBrouillon { get; }
    public Message.Publie EtatPublie { get; }
}
