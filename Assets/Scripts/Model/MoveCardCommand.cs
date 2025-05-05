namespace SolitaireTest.Assets.Scripts.Model
{
    public class MoveCardCommand : ICommand
    {
        private Card card;
        private IPile fromPile;
        private IPile toPile;

        public MoveCardCommand(Card card, IPile toPile)
        {
            this.card = card;
            this.fromPile = card.CurrentPile;
            this.toPile = toPile;
        }

        public void Execute()
        {
            fromPile.RemoveCard(card);
            toPile.AddCard(card);
        }

        public void Undo()
        {
            toPile.RemoveCard(card);
            fromPile.AddCard(card);
        }
    }
}