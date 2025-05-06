using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SolitaireTest.Assets.Scripts.View
{
    public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        private Vector3 startPosition;
        private Transform originalParent;
        private Action _onPickCallback;
        private Action<GameObject> _onDropCallback;

        public void SetCallbacks(Action onPickCallback, Action<GameObject> onDropCallback)
        {
            _onPickCallback = onPickCallback;
            _onDropCallback = onDropCallback;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            startPosition = transform.position;
            originalParent = transform.parent;
            _canvasGroup.blocksRaycasts = false;
            transform.SetParent(transform.root); // Bring to top
            _onPickCallback?.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            GameObject hitObject = eventData.pointerEnter;
            _onDropCallback?.Invoke(hitObject);
        }

        public void ResetPosition()
        {
            transform.SetParent(originalParent);
            transform.position = startPosition;
        }

        public void SetPositionToPile(GameObject pileGO)
        {
            transform.SetParent(pileGO.transform);
            transform.localPosition = Vector3.zero;
        }

        public void SetInteractable(bool isInteractable)
        {
            _canvasGroup.blocksRaycasts = isInteractable;
        }
    }
}