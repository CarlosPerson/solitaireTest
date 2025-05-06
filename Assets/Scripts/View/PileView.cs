using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SolitaireTest.Assets.Scripts.View
{
    public class PileView : MonoBehaviour
    {
        public string PileName { get; private set; }

        public void Setup(string pileName)
        {
            if (string.IsNullOrEmpty(pileName))
            {
                Debug.LogError($"Pile name cannot be null or empty. Pile: {pileName}");
                return;
            }
            gameObject.name = pileName;
            PileName = pileName;
        }
    }
}