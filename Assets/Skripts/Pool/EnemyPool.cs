using System.Collections;
using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    [SerializeField] private EnemyFactory _factory;
    [SerializeField] private EnemyContainer _enemyContainer;
    [SerializeField] private BulletContainer _bulletContainer;
    [SerializeField] private EnemyTargetPositionStash _positionStash;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _delay;
    
    public void Initialize(PlayerShip player) => _factory.Initialize(player, _bulletContainer);

    public void StartSpawning() => StartCoroutine(GetDelayed());

    public override Enemy Get(Vector2 position)
    {
        Enemy newEnemy;

        if (Objects.Count == 0)
        {
            newEnemy = _factory.Produce();
            newEnemy.Died += Release;

            _enemyContainer.Add(newEnemy);
            Objects.Enqueue(newEnemy);
        }

        newEnemy = Objects.Dequeue();
        newEnemy.transform.position = position;

        if (_positionStash.TryGetFreePosition(out Vector2 targetPosition))
        {
            newEnemy.gameObject.SetActive(true);
            newEnemy.Revive(targetPosition);
            return newEnemy;
        }
        else
        {
            Release(newEnemy);
            return null;
        }
    }

    public override void Clear()
    {
        foreach (Enemy enemy in Objects)
            enemy.Died -= Release;

        Objects.Clear();
        _enemyContainer.Clear();
    }

    private IEnumerator GetDelayed()
    {
        var delay = new WaitForSeconds(_delay);

        while (enabled)
        {
            Get(_spawnPoint.position);
            yield return delay;
        }
    }
}
