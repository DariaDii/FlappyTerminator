using System;

public class EndGameScreen : Window
{
    public event Action RestartButtonCliked;

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
        RestartButtonCliked?.Invoke();
    }
}