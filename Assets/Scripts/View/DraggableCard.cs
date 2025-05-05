using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace SolitaireTest.Assets.Scripts.View
{
    public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Vector3 startPosition;
        private Transform originalParent;
        private CanvasGroup canvasGroup;

        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            startPosition = transform.position;
            originalParent = transform.parent;
            canvasGroup.blocksRaycasts = false;
            transform.SetParent(transform.root); // Bring to top
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = true;
            GameObject hitObject = eventData.pointerEnter;
            if (hitObject != null && hitObject.transform != originalParent)
            {
                transform.SetParent(hitObject.transform);
                transform.localPosition = Vector3.zero;
            }
            else
            {
                transform.SetParent(originalParent);
                transform.position = startPosition;
            }
        }
    }
}