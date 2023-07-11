using UnityEngine;

public class UIScreen : MonoBehaviour
{
    [SerializeField] private GameObject _root;

    public virtual void Show(string text = null)
    {
        _root.SetActive(true);
    }

    public virtual void Hide()
    {
        _root.SetActive(false);
    }
}
