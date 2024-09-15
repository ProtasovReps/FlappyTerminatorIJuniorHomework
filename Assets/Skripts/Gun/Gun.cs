using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] private GunInfo _gunInfo;
    [SerializeField] private BulletPool _bulletPool;

    protected BulletPool BulletPool => _bulletPool;
    protected float ReloadTime => _gunInfo.ReloadTime;
    protected float ShootForce => _gunInfo.ShootForce;

    public void Initialize(BulletContainer container) => _bulletPool.Initialize(_gunInfo.Bullet, container, _gunInfo.Damage);

    public abstract void Shoot();

    public abstract void StopShooting();

    protected abstract void Reload();
}
