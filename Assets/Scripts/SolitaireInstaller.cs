
using System;
using System.Collections.Generic;
using System.Linq;
using SolitaireTest.Assets.Scripts;
using SolitaireTest.Assets.Scripts.Model;
using UnityEngine;

public class SolitaireInstaller : MonoBehaviour
{
    [SerializeField] private SolitaireManager _solitaireManager;
    public void Start()
    {
        List<IPile> pileModels = InstantiatePileModels();
        List<Card> cardModels = InstantiateCardModels(pileModels.FirstOrDefault());
        _solitaireManager.Setup(cardModels, pileModels);
    }

    private List<IPile> InstantiatePileModels()
    {
        List<IPile> pileModels = new List<IPile>();
        string[] pileNames = { "DeckPile", "HeartsPile", "DiamondsPile", "ClubsPile", "SpadesPile" };
        foreach (string pileName in pileNames)
        {
            IPile pile = new NoRulesPile(pileName);
            pileModels.Add(pile);
        }
        return pileModels;
    }

    private List<Card> InstantiateCardModels(IPile defaultPile)
    {
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        List<Card> cardModels = new List<Card>();
        for (int i = 0; i < suits.Length; i++)
        {
            for (int j = 0; j < ranks.Length; j++)
            {
                Card card = new Card(ranks[j], suits[i], defaultPile);
                cardModels.Add(card);
            }
        }
        return cardModels;
    }
}