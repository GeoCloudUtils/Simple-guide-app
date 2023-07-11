using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDetailedViewScreen : UIScreen
{
    [SerializeField] private Button _closeButton;

    [SerializeField] private TMP_Text _viewText;

    private void Start()
    {
        _closeButton.onClick.AddListener(Hide);
    }

    public override void Hide()
    {
        base.Hide();
    }

    public override void Show(string text)
    {
        base.Show();
        _viewText.SetText(text);
    }
}
