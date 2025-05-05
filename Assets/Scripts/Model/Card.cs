using UnityEngine;

namespace SolitaireTest.Assets.Scripts.Model
{
    public class Card
    {
        public string Name { get; set; }  // e.g., "Ace of Spades"
        public IPile CurrentPile { get; set; }

        public Card(string name, IPile initialPile)
        {
            if (string.IsNullOrEmpty(name))
            {
                Debug.LogError($"Card name cannot be null or empty. Card: {name}");
                return;
            }
            if (initialPile == null)
            {
                Debug.LogError($"Initial pile cannot be null. Card: {name}");
                return;
            }

            Name = name;
            CurrentPile = initialPile;
            initialPile.AddCard(this);
        }
    }
}
