namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public partial class Message
{
    public class Brouillon : AbstractEtatCommands
    {
        public Brouillon(Message message)
            : base(message)
        {
            // Nothing to do.
        }

        public override Etat AsEnum() => Etat.Brouillon;

        public override void Valider()
        {
            Message._etat = Message._etatPublie;
        }
    }
}
