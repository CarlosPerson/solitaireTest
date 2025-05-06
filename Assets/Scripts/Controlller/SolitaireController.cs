using UnityEngine;
using System.Collections.Generic;
using SolitaireTest.Assets.Scripts.View;
using SolitaireTest.Assets.Scripts.Model;

namespace SolitaireTest.Assets.Scripts.Controller
{
    public class SolitaireController : MonoBehaviour
    {
        [SerializeField] private GameObject _cardPrefab, _pilePrefab;
        [SerializeField] private Transform _pileParent;
        [SerializeField] private UndoView _undoView;
        private List<CardView> _cardViews = new List<CardView>();
        private List<GameObject> _pileGOs = new List<GameObject>();
        private Dictionary<string, GameObject> _pileNameToGOs = new Dictionary<string, GameObject>();
        private List<Card> _cardModels;
        private List<IPile> _pileModels;
        private ICommandManager _commandManager;

        public void Setup(List<Card> cardModels, List<IPile> pileModels, ICommandManager commandManager)
        {
            if (_cardPrefab == null || _pilePrefab == null || _pileParent == null)
            {
                Debug.LogError("Card prefab, pile prefab, or pile parent is not assigned in the inspector.");
                return;
            }
            if (cardModels == null || pileModels == null)
            {
                Debug.LogError("Card models or stack models cannot be null.");
                return;
            }
            _cardModels = cardModels;
            _pileModels = pileModels;
            _commandManager = commandManager;

            InstantiatePileGOs();
            InstantiateCardGOs();
            SetupUseCases();
        }

        private void InstantiatePileGOs()
        {
            foreach (IPile pile in _pileModels)
            {
                GameObject pileGO = Instantiate(_pilePrefab);
                _pileGOs.Add(pileGO);
                pileGO.transform.SetParent(_pileParent, false);
                _pileNameToGOs[pile.Name] = pileGO;
                PileView pileView = pileGO.GetComponent<PileView>();
                pileView.Setup(pile.Name);
            }
        }

        void InstantiateCardGOs()
        {
            foreach (Card card in _cardModels)
            {
                GameObject cardGO = Instantiate(_cardPrefab);
                CardView cardView = cardGO.GetComponent<CardView>();
                if (cardView == null)
                {
                    Debug.LogError("CardView component is missing on the prefab.");
                    continue;
                }
                else
                {
                    cardView.Setup(card.Rank, card.Suit, _pileNameToGOs[card.CurrentPile.Name]);
                }
                _cardViews.Add(cardView);
            }
        }

        private void SetupUseCases()
        {
            foreach (CardView cardView in _cardViews)
            {
                cardView.OnCardPicked += OnCardPickedUseCase;
                cardView.OnCardDropped += OnCardDroppedUseCase;
            }
            foreach (IPile pile in _pileModels)
            {
                pile.OnCardAdded += OnCardAddedToPileUseCase;
            }
            _undoView.OnUndoButtonClicked += OnUndoRequestedUseCase;
        }

        private void OnCardPickedUseCase(CardView cardView)
        {
            foreach (CardView otherCardView in _cardViews)
            {
                if (otherCardView != cardView)
                {
                    otherCardView.SetInteractable(false);
                }
            }
        }

        private void OnCardDroppedUseCase(GameObject hitObject, CardView cardView)
        {
            foreach (CardView card in _cardViews)
            {
                card.SetInteractable(true);
            }
            if (hitObject == null)
            {
                cardView.ResetPosition();
                Debug.Log($"No object hit with drop");
            }
            else if (hitObject.TryGetComponent<PileView>(out PileView pileView))
            {
                if (_pileNameToGOs.TryGetValue(pileView.PileName, out GameObject pileGO))
                {
                    IPile targetPile = _pileModels.Find(p => p.Name == pileView.PileName);
                    Card cardModel = _cardModels.Find(x => x.Rank == cardView.Rank && x.Suit == cardView.Suit);
                    _commandManager.ExecuteCommand(new MoveCardCommand(cardModel, targetPile));
                }
                else
                {
                    Debug.LogError($"No pile found with name: {pileView.PileName}");
                    cardView.ResetPosition();
                }
            }
            else
            {
                cardView.ResetPosition();
                Debug.Log($"No PileView component found on the hit object: {hitObject.name}");
            }
        }


        private void OnCardAddedToPileUseCase(ICard card, IPile pile)
        {
            if (_pileNameToGOs.TryGetValue(pile.Name, out GameObject pileGO))
            {
                CardView cardView = _cardViews.Find(x => x.Rank == card.Rank && x.Suit == card.Suit);
                if (cardView != null)
                {
                    cardView.SetPositionToPile(pileGO);
                }
                else
                {
                    Debug.LogError($"No CardView found for card: {card.Name}");
                }
            }
            else
            {
                Debug.LogError($"No pile found with name: {pile.Name}");
            }
        }
        private void OnUndoRequestedUseCase()
        {
            _commandManager.UndoLastCommand();
        }
    }
}