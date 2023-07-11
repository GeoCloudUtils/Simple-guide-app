using System.Collections.Generic;
using UnityEngine;
public enum GuideType
{
    ITEMS,
    TIPS,
    WEAPONS,
    LOCATIONS 
}

public enum Language
{
    ENGLISH,
    SPANISH
}

[CreateAssetMenu(fileName = "Guide", menuName = "ScriptableObjects/Guide Data", order = 1)]
public class Guide : ScriptableObject
{
    [SerializeField] private List<GuideDefinition> _guides;

    public List<GuideDefinition> Guides { get => _guides; }

    public List<GuideData> GetGuideDataByType(GuideType type, Language language)
    {
        GuideDefinition def = _guides.Find(g => g.Type == type);
        Data guideData = def.Data.Find(e => e.Language == language);
        return guideData.GuideList;
    }
}

[System.Serializable]
public class GuideDefinition
{
    public GuideType Type;
    public List<Data> Data;
}

[System.Serializable]
public class Data
{
    public Language Language;
    public List<GuideData> GuideList;
}

[System.Serializable]
public class GuideData
{
    public string EntryText;
    [TextArea]
    public string DetailsText;
}
