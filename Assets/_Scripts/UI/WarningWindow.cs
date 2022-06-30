
using System;
using TMPro;
using UnityEngine;

public class WarningWindow : MonoBehaviour
{
    private const string confirmMessage = "Вы действительно хотите приобрести данный предмет?";
    private const string notEnoughtMoneyMessage = "На счету недостаточно средств";
    [SerializeField] private CanvasGroup _confirmPanel;
    [SerializeField] private CanvasGroup _warningPanel;
    [SerializeField] private CanvasGroup _warningWindow;
    [SerializeField] private TextMeshProUGUI _messageText;
    public Action onBuyButtonClicked;
    public void ShowConfirmMessage()
    {
        _warningWindow.alpha = 1;
        _warningWindow.blocksRaycasts = true;
        _messageText.text = confirmMessage;
        _confirmPanel.alpha = 1;
        _warningPanel.alpha = 0;
    }

    public void ShowWarningMessage()
    {
        _warningWindow.alpha = 1;
        _warningWindow.blocksRaycasts = true;
        _messageText.text = notEnoughtMoneyMessage;
        _confirmPanel.alpha = 0;
        _warningPanel.alpha = 1;
    }
    public void BuyButtonClicked()
    {
        onBuyButtonClicked?.Invoke();
    }
    public void CloseWindow()
    {
        _warningWindow.alpha = 0;
        _warningWindow.blocksRaycasts = false;
    }
}
