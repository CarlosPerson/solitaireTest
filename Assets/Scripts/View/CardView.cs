using UnityEngine;
using TMPro;
using System;

namespace SolitaireTest.Assets.Scripts.View
{
    public class CardView : MonoBehaviour
    {
        public Action<CardView> OnCardPicked;
        public Action<GameObject, CardView> OnCardDropped;

        [SerializeField] private TextMeshProUGUI _rankText;
        [SerializeField] private TextMeshProUGUI _suitText;
        [SerializeField] private DraggableCard _draggableCard;
        public string Rank { get; private set; }
        public string Suit { get; private set; }

        public void Setup(string rank, string suit, GameObject initialPileGO)
        {
            if (_rankText == null)
            {
                Debug.LogError("_rankText is not assigned. Cannot set up card view.");
                return;
            }
            if (_suitText == null)
            {
                Debug.LogError("_suitText is not assigned. Cannot set up card view.");
                return;
            }
            if (_draggableCard == null)
            {
                Debug.LogError("_draggableCard is not assigned. Cannot set up card view.. Cannot set up card view.");
                return;
            }

            Rank = rank;
            Suit = suit;
            _rankText.text = rank;
            _suitText.text = suit;

            gameObject.name = $"{rank} of {suit} GO";
            _draggableCard.SetPositionToPile(initialPileGO);
            _draggableCard.SetCallbacks(
                () => OnCardPicked?.Invoke(this),
                hitObject => DropCard(hitObject)
            );
        }

        public void DropCard(GameObject hitObject)
        {
            OnCardDropped?.Invoke(hitObject, this);
        }

        public void ResetPosition()
        {
            _draggableCard.ResetPosition();
        }

        public void SetPositionToPile(GameObject pileGO)
        {
            _draggableCard.SetPositionToPile(pileGO);
        }

        public void SetInteractable(bool isInteractable)
        {
            _draggableCard.SetInteractable(isInteractable);
        }
    }
}