using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIListScreen : UIScreen
{
    [SerializeField] private Transform _entrySpawnTransform;

    [SerializeField] private UIScreen _detailedView;

    [SerializeField] private Button _closeButton;

    [SerializeField] private UIScreen _uiMainScreen;

    [SerializeField] private TMP_Dropdown _dropdown;

    [SerializeField] private Guide _guideController;

    [SerializeField] private GuideEntry _entryInstance;

    private readonly List<GameObject> _spawnedEntries = new List<GameObject>();

    private void Start()
    {
        _dropdown.onValueChanged.AddListener(LanguageChanged);
        _closeButton.onClick.AddListener(Hide);
    }

    private void LanguageChanged(int index)
    {
        DestroySpawnedEntries();
        _spawnedEntries.Clear();
        DisplayContent((Language)index);
    }

    private void DestroySpawnedEntries()
    {
        foreach (GameObject entry in _spawnedEntries)
        {
            Destroy(entry);
        }
    }

    private void DisplayContent(Language language)
    {
        List<GuideData> selectedGuideData = _guideController.GetGuideDataByType(UIMainScreen.SelectedGuideType, language);
        if (selectedGuideData == null)
        {
            Debug.LogError("Can't find guide of type: " + UIMainScreen.SelectedGuideType);
            return;
        }
        foreach (GuideData data in selectedGuideData)
        {
            GuideEntry entry = Instantiate(_entryInstance, _entrySpawnTransform);
            entry.gameObject.SetActive(true);
            entry.GuideEntryText.SetText(data.EntryText);
            entry.DetailsText = data.DetailsText;
            entry.EntryClick += EntryClick;
            _spawnedEntries.Add(entry.gameObject);
        }
    }

    private void EntryClick(string text)
    {
        _detailedView.Show(text);
    }

    public override void Hide()
    {
        _uiMainScreen.Show();
        base.Hide();
    }

    public override void Show(string text = null)
    {
        _dropdown.value = 0;
        LanguageChanged(0);
        base.Show(text);
    }
}
