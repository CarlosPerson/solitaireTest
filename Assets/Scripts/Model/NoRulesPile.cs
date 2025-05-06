using System;
using System.Collections.Generic;
using UnityEngine;

namespace SolitaireTest.Assets.Scripts.Model
{
    public class NoRulesPile : IPile
    {
        public string Name { get; private set; }
        public IList<ICard> Cards { get; private set; }

        public NoRulesPile(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Debug.LogError($"Pile name cannot be null or empty. Pile: {name}");
                return;
            }

            Name = name;
            Cards = new List<ICard>();
        }

        public event Action<ICard, IPile> OnCardAdded;

        public void AddCard(ICard card)
        {
            Cards.Add(card);
            card.CurrentPile = this;
            OnCardAdded?.Invoke(card, this);
        }

        public void RemoveCard(ICard card)
        {
            Cards.Remove(card);
        }
    }
}