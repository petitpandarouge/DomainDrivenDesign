namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public partial class Message
{
    public class Publie : EtatCommands
    {
        public Publie(Message message)
            : base(message)
        {
            // Nothing to do.
        }

        public override Etat AsEnum() => Etat.Publie;

        public override void SetTitre(Titre titre)
        {
            throw new InvalidOperationException("Le message est publié, il ne peut plus être modifié.");
        }

        public override void Valider()
        {
            throw new InvalidOperationException("Seul un brouillon peut être validé.");
        }
    }
}
