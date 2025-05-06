using System;
using System.Collections.Generic;
using UnityEngine;

namespace SolitaireTest.Assets.Scripts.Model
{
    public class NoRulesPile : IPile
    {
        public string Name { get; private set; }
        public IList<Card> Cards { get; private set; }

        public NoRulesPile(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Debug.LogError($"Pile name cannot be null or empty. Pile: {name}");
                return;
            }

            Name = name;
            Cards = new List<Card>();
        }

        public event Action<Card, IPile> OnCardAdded;

        public void AddCard(Card card)
        {
            Cards.Add(card);
            card.CurrentPile = this;
            OnCardAdded?.Invoke(card, this);
        }

        public void RemoveCard(Card card)
        {
            Cards.Remove(card);
        }
    }
}