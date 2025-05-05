using UnityEngine;
using TMPro;

public class CardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rankText;
    [SerializeField] private TextMeshProUGUI _suitText;


    public void Setup(string rank, string suit)
    {
        if (_rankText == null)
        {
            Debug.LogError("_rankText is not assigned. Cannot set up card view.");
            return;
        }
        _rankText.text = rank;

        if (_suitText == null)
        {
            Debug.LogError("_suitText is not assigned. Cannot set up card view.");
            return;
        }
        _suitText.text = suit;
    }
}