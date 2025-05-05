using System.Collections.Generic;

namespace SolitaireTest.Assets.Scripts.Model
{
    public interface IPile
    {
        string Name { get; }
        IList<Card> Cards { get; }

        void AddCard(Card card);
        void RemoveCard(Card card);
    }
}