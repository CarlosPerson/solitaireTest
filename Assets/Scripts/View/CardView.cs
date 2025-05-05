using UnityEngine;
using TMPro;

namespace SolitaireTest.Assets.Scripts.View
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _rankText;
        [SerializeField] private TextMeshProUGUI _suitText;

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
            _rankText.text = rank;
            _suitText.text = suit;

            gameObject.name = $"{rank} of {suit} GO";
            transform.SetParent(initialPileGO.transform, false);
        }
    }
}