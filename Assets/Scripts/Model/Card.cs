using UnityEngine;

namespace SolitaireTest.Assets.Scripts.Model
{
    public class Card
    {
        public string Rank { get; private set; }
        public string Suit { get; private set; }
        public IPile CurrentPile { get; set; }

        public string Name => $"{Rank} of {Suit}";

        public Card(string rank, string suit, IPile initialPile)
        {
            if (string.IsNullOrEmpty(rank))
            {
                Debug.LogError($"Card rank cannot be null or empty. Card: {rank}");
                return;
            }
            if (string.IsNullOrEmpty(suit))
            {
                Debug.LogError($"Card suit cannot be null or empty. Card: {suit}");
                return;
            }
            if (initialPile == null)
            {
                Debug.LogError($"Initial pile cannot be null. Card: {Name}");
                return;
            }
            Rank = rank;
            Suit = suit;
            CurrentPile = initialPile;
            initialPile.AddCard(this);
        }
    }
}
