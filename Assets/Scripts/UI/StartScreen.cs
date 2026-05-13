using System;

public class StartScreen : Window
{
    public event Action PlayButtonCliked;

    public override void Close()
    {
        gameObject.SetActive(false);
        ActionButton.interactable = false;
    }

    public override void Open()
    {
        gameObject.SetActive(true);
        ActionButton.interactable = true;
    }

    protected override void OnButtonlick()
    {
        PlayButtonCliked?.Invoke();
    }
}