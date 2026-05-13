using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field:SerializeField] public EnemyAttack EnemyAttack { get; private set; }

    public event Action<Enemy> Destruction;

    public void Death()
    {
        Destruction?.Invoke(this);
    }
}