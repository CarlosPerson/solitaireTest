using System.Collections.Generic;
using SolitaireTest.Assets.Scripts.Controller;
using SolitaireTest.Assets.Scripts.Model;
using UnityEngine;

public class SolitaireInstaller : MonoBehaviour
{
    [SerializeField] private SolitaireController _solitaireManager;
    public void Start()
    {
        if (_solitaireManager == null)
        {
            Debug.LogError("SolitaireManager is not assigned in the inspector.");
            return;
        }
        List<IPile> pileModels = InstantiatePileModels();
        List<Card> cardModels = InstantiateCardModels(pileModels.Find(x=> x.Name == "DeckPile"));
        _solitaireManager.Setup(cardModels, pileModels, new CommandManager());
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