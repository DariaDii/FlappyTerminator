using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonCliked +=OnPlayButtonClick;
        _endScreen.RestartButtonCliked +=OnRestartButtonClick;
        _player.GameOver +=OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonCliked -= OnPlayButtonClick;
        _endScreen.RestartButtonCliked -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0f;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0f;
        _endScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        _player.Reset();
    }
}