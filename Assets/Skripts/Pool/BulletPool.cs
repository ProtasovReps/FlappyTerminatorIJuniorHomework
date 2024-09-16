using UnityEngine;

public class BulletPool : ObjectPool<Bullet>
{
    private Bullet _prefab;
    private Container _container;
    private int _bulletDamage;

    public void Initialize(Container bulletContainer, Bullet prefab, int bulletDamage)
    {
        _container = bulletContainer;
        _prefab = prefab;
        _bulletDamage = bulletDamage;
    }

    public override Bullet Get(Vector2 position)
    {
        Bullet bullet;

        if (FreeObjects.Count == 0)
        {
            bullet = Instantiate(_prefab);
            bullet.Initialize(_bulletDamage);
            bullet.WorkedOut += Release;

            bullet.transform.SetParent(_container.transform);
            AllObjects.Add(bullet);
            FreeObjects.Enqueue(bullet);
        }

        bullet = FreeObjects.Dequeue();
        bullet.transform.position = position;

        bullet.gameObject.SetActive(true);
        return bullet;
    }
}