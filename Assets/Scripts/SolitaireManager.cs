using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace SolitaireTest.Assets.Scripts
{
    public class SolitaireManager : MonoBehaviour
    {
        public GameObject cardPrefab;
        public Transform[] stacks;

        private List<GameObject> cards = new List<GameObject>();

        void Start()
        {
            GenerateDeck();
            DealCards();
        }

        void GenerateDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    GameObject card = Instantiate(cardPrefab);
                    card.name = $"{ranks[j]} of {suits[i]}";
                    card.transform.SetParent(transform);
                    card.transform.localScale = Vector3.one;
                    CardView cardView = card.GetComponent<CardView>();
                    cardView.Setup(ranks[j], suits[i]);
                    cards.Add(card);
                }
            }
        }

        void DealCards()
        {
            cards.Shuffle();
            foreach (GameObject card in cards)
            {
                int stackIndex = UnityEngine.Random.Range(0, stacks.Length);
                card.transform.SetParent(stacks[stackIndex]);
                card.transform.localPosition = Vector3.zero;
            }
        }

    }
}