using System.Collections;
using UnityEngine;

public class EnemyAttack : GeneralAttack
{
    [SerializeField] private float _delay;
    [SerializeField] private float _minInitialDelay = 0f;
    [SerializeField] private float _maxInitialDelay = 2f;

    private void Start()
    {
        float randomDelay = Random.Range(_minInitialDelay, _maxInitialDelay);
        StartCoroutine(Reload(randomDelay));
    }

    private IEnumerator Reload(float initialDelay)
    {
        yield return new WaitForSeconds(initialDelay);
        {
            var delay = new WaitForSeconds(_delay);

            while (enabled)
            {
                Attack();
                yield return delay;
            }
        }
    }

    public override void Attack()
    {
        base.Attack();
    }
}