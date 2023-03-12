namespace DomainDrivenDesign.Domain.Entities.MessageAggregate;

public partial class Message
{
    public class Publie : EtatCommands
    {
        public const string MSG_CANNOT_BE_MODIFIED_ERROR_MSG = "Le message est publié, il ne peut plus être modifié.";

        public Publie(Message message)
            : base(message)
        {
            // Nothing to do.
        }

        public override Etat AsEnum() => Etat.Publie;

        public override void SetTitre(Titre titre)
        {
            throw new InvalidOperationException(MSG_CANNOT_BE_MODIFIED_ERROR_MSG);
        }

        public override void Valider()
        {
            throw new InvalidOperationException(ONLY_BROUILLON_CAN_BE_VALIDE_ERROR_MSG);
        }
    }
}
