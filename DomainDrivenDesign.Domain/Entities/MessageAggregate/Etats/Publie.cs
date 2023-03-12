namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public partial class Message
{
    public class Publie : AbstractEtatCommands
    {
        public Publie(Message message)
            : base(message)
        {
            // Nothing to do.
        }

        public override Etat AsEnum() => Etat.Publie;

        public override void Valider()
        {
            throw new NotImplementedException();
        }
    }
}
