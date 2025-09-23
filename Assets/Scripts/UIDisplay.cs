using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinTxt;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (coinTxt != null && CoinsManager.Instance != null)
        {
            coinTxt.text = CoinsManager.Instance.Score.ToString();
        }
    }
}
