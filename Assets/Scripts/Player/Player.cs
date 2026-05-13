using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private void OnEnable()
    {
        _inputReader.Moved +=_playerMover.Move;
        _inputReader.Attacked += _playerAttack.Attack;
    }

    private void OnDisable()
    {
        _inputReader.Moved -= _playerMover.Move;
        _inputReader.Attacked -= _playerAttack.Attack;
    }

    public void Death()
    {
        _inputReader.enabled = false;
        GameOver?.Invoke();
    }

    public void Reset()
    {
        _inputReader.enabled =true;
        _playerMover.Reset();
        _scoreCounter.Reset();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Enemy enemy))
        {
            Death();
        }
    }
}