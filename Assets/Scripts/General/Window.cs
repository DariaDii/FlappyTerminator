using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private Button _actionButton;

    protected Button ActionButton => _actionButton;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonlick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonlick);
    }

    protected abstract void OnButtonlick();

    public abstract void Open();
    public abstract void Close();
}