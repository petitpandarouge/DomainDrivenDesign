namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public partial class Message
{
    public class Brouillon : EtatCommands
    {
        public Brouillon(Message message)
            : base(message)
        {
            // Nothing to do.
        }

        public override Etat AsEnum() => Etat.Brouillon;

        public override void Delete()
        {
            Message._etat = Message._etatDeleting;
            Message.Id = Guid.Empty;
        }

        public override void SetTitre(Titre titre)
        {
            Message._titre = titre;
        }

        public override void Valider()
        {
            Message._etat = Message._etatPublie;
        }
    }
}
