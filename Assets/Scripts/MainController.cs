using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Language
{
    ENGLISH,
    SPANISH
}

public class MainController : MonoBehaviour
{
    [SerializeField] private Transform _entrySpawnTransform;

    [SerializeField] private UIAbstractScreen _detailedView;

    [SerializeField] private TMP_Dropdown _dropdown;

    [SerializeField] private Guide _guideData;

    [SerializeField] private GuideEntry _entryInstance;

    private readonly List<GameObject> _spawnedEntries = new List<GameObject>();

    private void Start()
    {
        _dropdown.onValueChanged.AddListener(LanguageChanged);
        LanguageChanged(0);
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
        List<GuideData> selectedGuideData = GetSelectedGuideData(language);
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

    private List<GuideData> GetSelectedGuideData(Language language)
    {
        return language == Language.ENGLISH ? _guideData.EnglishData : _guideData.SpanishData;
    }

    private void EntryClick(string text)
    {
        _detailedView.Show(text);
    }
}
