using System;
using UnityEngine;

namespace SolitaireTest.Assets.Scripts.View
{
    public class UndoView : MonoBehaviour
    {
        public Action OnUndoButtonClicked;
        public void ClickUndo()
        {
            Debug.Log("Undo button clicked.");
            OnUndoButtonClicked?.Invoke();
        }
    }
}