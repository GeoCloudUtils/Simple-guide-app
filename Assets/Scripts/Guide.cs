using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Guide", menuName = "ScriptableObjects/Guide Data", order = 1)]
public class Guide : ScriptableObject
{
    [SerializeField] private List<GuideData> _englishData;
    [SerializeField] private List<GuideData> _spanishData;

    public List<GuideData> EnglishData { get => _englishData; }
    public List<GuideData> SpanishData { get => _spanishData; }
}

[System.Serializable]
public class GuideData
{
    public string EntryText;
    [TextArea]
    public string DetailsText;
}
