using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SolitaireTest.Assets.Scripts.Model;
using System.Collections.Generic;


namespace SolitaireTest.Assets.Scripts.Model.Tests
{
    public class NoRulesPileTests
    {
        private NoRulesPile _pile;

        [SetUp]
        public void SetUp()
        {
            _pile = new NoRulesPile("TestPile");
        }

        [Test]
        public void Constructor_ValidName_InitializesCorrectly()
        {
            Assert.AreEqual("TestPile", _pile.Name);
            Assert.IsNotNull(_pile.Cards);
            Assert.IsEmpty(_pile.Cards);
        }

        [Test]
        public void Constructor_NullOrEmptyName_LogsError()
        {
            LogAssert.Expect(LogType.Error, "Pile name cannot be null or empty. Pile: ");
            var invalidPile = new NoRulesPile(null);
            Assert.IsNull(invalidPile.Name);
        }

        [Test]
        public void AddCard_ValidCard_AddsCardToPile()
        {
            var mockCard = new MockCard();
            _pile.AddCard(mockCard);

            Assert.Contains(mockCard, (ICollection)_pile.Cards);
            Assert.AreEqual(_pile, mockCard.CurrentPile);
        }

        [Test]
        public void AddCard_TriggersOnCardAddedEvent()
        {
            var mockCard = new MockCard();
            ICard addedCard = null;
            IPile addedToPile = null;

            _pile.OnCardAdded += (card, pile) =>
            {
                addedCard = card;
                addedToPile = pile;
            };

            _pile.AddCard(mockCard);

            Assert.AreEqual(mockCard, addedCard);
            Assert.AreEqual(_pile, addedToPile);
        }

        [Test]
        public void RemoveCard_ValidCard_RemovesCardFromPile()
        {
            var mockCard = new MockCard();
            _pile.AddCard(mockCard);

            _pile.RemoveCard(mockCard);

            Assert.IsFalse(_pile.Cards.Contains(mockCard));
        }
    }

    public class MockCard : ICard
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public string Rank { get; set; }
        public IPile CurrentPile { get; set; }
    }
}