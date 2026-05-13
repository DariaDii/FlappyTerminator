using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    private int _score;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        _enemySpawner.Released += Add;
    }

    private void OnDisable()
    {
        _enemySpawner.Released -= Add;
    }

    public void Add()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
