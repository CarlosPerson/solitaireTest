using UnityEngine;
using System.Collections.Generic;
using SolitaireTest.Assets.Scripts.View;
using SolitaireTest.Assets.Scripts.Utilities;
using SolitaireTest.Assets.Scripts.Model;
using System;

namespace SolitaireTest.Assets.Scripts
{
    public class SolitaireManager : MonoBehaviour
    {
        [SerializeField] private GameObject _cardPrefab, _pilePrefab;
        [SerializeField] private Transform _pileParent;
        private List<GameObject> _cardGOs = new List<GameObject>();
        private Dictionary<string, GameObject> _pileNameToGOs = new Dictionary<string, GameObject>();
        private List<Card> _cardModels;
        private List<IPile> _pileModels;

        public void Setup(List<Card> cardModels, List<IPile> pileModels)
        {
            if (cardModels == null || pileModels == null)
            {
                Debug.LogError("Card models or stack models cannot be null.");
                return;
            }
            _cardModels = cardModels;
            _pileModels = pileModels;

            InstantiatePileGOs();
            InstantiateCardGOs();
        }

        private void InstantiatePileGOs()
        {
            foreach (IPile pile in _pileModels)
            {
                GameObject pileGO = new GameObject(pile.Name);
                pileGO.transform.SetParent(_pileParent, false);
                _pileNameToGOs[pile.Name] = pileGO;
            }
        }

        void InstantiateCardGOs()
        {
            foreach (Card card in _cardModels)
            {
                GameObject cardGO = Instantiate(_cardPrefab);
                CardView cardView = cardGO.GetComponent<CardView>();
                if (cardView != null)
                {
                    cardView.Setup(card.Rank, card.Suit, _pileNameToGOs[card.CurrentPile.Name]);
                }
                else
                {
                    Debug.LogError("CardView component is missing on the prefab.");
                }
                _cardGOs.Add(cardGO);
            }
        }
    }
}