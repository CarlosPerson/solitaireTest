using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

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
        for (int i = 0; i < 52; i++)
        {
            GameObject card = Instantiate(cardPrefab);
            card.name = "Card " + i;
            card.transform.SetParent(transform);
            card.transform.localScale = Vector3.one;
            card.AddComponent<CanvasGroup>();
            card.AddComponent<DraggableCard>();
            cards.Add(card);
        }
    }

    void DealCards()
    {
        for (int i = 0; i < stacks.Length && i < cards.Count; i++)
        {
            cards[i].transform.SetParent(stacks[i]);
            cards[i].transform.localPosition = Vector3.zero;
        }
    }
}
