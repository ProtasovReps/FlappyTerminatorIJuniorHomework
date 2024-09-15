using UnityEngine;

public class BulletPool : ObjectPool<Bullet>
{
    private int _bulletDamage;
    private Bullet _prefab;
    private BulletContainer _container;

    public void Initialize(Bullet prefab, BulletContainer container, int bulletDamage)
    {
        _prefab = prefab;
        _container = container;
        _bulletDamage = bulletDamage;
    }

    public override Bullet Get(Vector2 position)
    {
        Bullet bullet;

        if (Objects.Count == 0)
        {
            bullet = Instantiate(_prefab);
            bullet.Initialize(_bulletDamage);
            bullet.WorkedOut += Release;

            _container.Add(bullet);
            Objects.Enqueue(bullet);
        }

        bullet = Objects.Dequeue();
        bullet.transform.position = position;

        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public override void Clear()
    {
        foreach (Bullet bullet in Objects)
            bullet.WorkedOut -= Release;

        Objects.Clear();
        _container.Clear();
    }
}