using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuideEntry : MonoBehaviour
{
    [SerializeField] private Button _entryButton;

    [SerializeField] private TMP_Text _guideEntryText;

    public string DetailsText;

    public TMP_Text GuideEntryText { get => _guideEntryText; set => _guideEntryText = value; }

    public delegate void OnEntryClick(string text);
    public event OnEntryClick EntryClick;

    private void Start()
    {
        _entryButton.onClick.AddListener(ShowDetails);
    }

    private void ShowDetails()
    {
        EntryClick?.Invoke(DetailsText);
    }
}
