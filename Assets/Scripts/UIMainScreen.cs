using UnityEngine;
using UnityEngine.UI;

public class UIMainScreen : UIScreen
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Button _rateButton;
    [SerializeField] private Button _moreAppsButton;

    [SerializeField] private UIListScreen _uiListScreen;

    private static GuideType selectedGuideType;

    public static GuideType SelectedGuideType { get => selectedGuideType; }

    private const string APP_STORE_URL = "https://play.google.com/";
    private const string PLAY_STORE_URL = "https://www.apple.com/app-store/";

    private void Start()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            int k = i;
            Button button = _buttons[i];
            button.onClick.AddListener(() => Click(k));
        }
        _rateButton.onClick.AddListener(OpenStore);
        _moreAppsButton.onClick.AddListener(OpenStoreApps);
        Show();
    }

    private void OpenStoreApps()
    {
#if UNITY_ANDROID
        Application.OpenURL(PLAY_STORE_URL);
#elif UNITY_IOS
        Application.OpenURL(APP_STORE_URL);
#endif
    }

    private void OpenStore()
    {
#if UNITY_ANDROID
        Application.OpenURL(PLAY_STORE_URL);
#elif UNITY_IOS
        Application.OpenURL(APP_STORE_URL);
#endif
    }

    private void Click(int index)
    {
        selectedGuideType = (GuideType)index;
        _uiListScreen.Show();
        Hide();
    }

    public override void Show(string text = null)
    {
        base.Show(text);
    }

    public override void Hide()
    {
        base.Hide();
    }
}
