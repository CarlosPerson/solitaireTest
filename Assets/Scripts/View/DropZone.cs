using UnityEngine;
using UnityEngine.EventSystems;

namespace SolitaireTest.Assets.Scripts.View
{
    public class DropZone : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            /*
            GameObject dropped = eventData.pointerDrag;
            if (dropped != null)
            {
                dropped.transform.SetParent(transform);
                dropped.transform.localPosition = Vector3.zero;
            }*/
        }
    }
}