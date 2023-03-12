﻿namespace DomainDrivenDesign.Domain.Tests.Entities.MessageAggregate;

public class EtatFixture
{
    public EtatFixture()
    {
        Fixture fixture = new();
        string titre = fixture.Create<string>();
        string description = fixture.Create<string>();
        IEnumerable<string> tags = fixture.CreateMany<string>();
        DateTime now = fixture.Create<DateTime>();

        Message = new(titre, description, tags, now);
        EtatBrouillon = new (Message);
        EtatPublie = new (Message);
        EtatDeleting = new(Message);
    }

    public Message Message { get; }
    public Message.Brouillon EtatBrouillon { get; }
    public Message.Publie EtatPublie { get; }
    public Message.Deleting EtatDeleting { get; }
}
