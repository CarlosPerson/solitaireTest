using System;
using System.Collections.Generic;

namespace SolitaireTest.Assets.Scripts.Model
{
    public interface IPile
    {
        string Name { get; }
        IList<ICard> Cards { get; }
        event Action<ICard, IPile> OnCardAdded;

        void AddCard(ICard card);
        void RemoveCard(ICard card);
    }
}