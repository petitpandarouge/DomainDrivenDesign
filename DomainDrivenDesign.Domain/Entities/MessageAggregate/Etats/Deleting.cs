namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public partial class Message
{
    public class Deleting : EtatCommands
    {
        public const string MSG_BEING_DELETED_ERROR_MSG = "Le message est en cours de suppression, aucun traitement ne peut être effectué.";

        public Deleting(Message message)
            : base(message)
        {
            // Nothing to do.
        }

        public override Etat AsEnum() => Etat.Deleting;

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void SetTitre(Titre titre)
        {
            throw new InvalidOperationException(MSG_BEING_DELETED_ERROR_MSG);
        }

        public override void Valider()
        {
            throw new InvalidOperationException(MSG_BEING_DELETED_ERROR_MSG);
        }
    }
}
