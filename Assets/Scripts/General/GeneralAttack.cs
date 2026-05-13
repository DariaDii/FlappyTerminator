using UnityEngine;

public abstract class GeneralAttack : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Transform _attackPoint;

    public void Init(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public virtual void Attack()
    {
        SpawnBullet();
    }

    private void SpawnBullet()
    {
        Bullet bullet = _bulletPool.GetObject();
        bullet.Released += Release;
        bullet.transform.position = _attackPoint.position;
        bullet.SetDirection(transform.right);
    }

    private void Release(Bullet bullet)
    {
        _bulletPool.ReturnToPool(bullet);
        bullet.Released -= Release;
    }
}