using System.Collections;
using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    [SerializeField] private EnemyFactory _factory;
    [SerializeField] private Container _enemyContainer;
    [SerializeField] private Container _bulletContainer;
    [SerializeField] private EnemyTargetPositionStash _positionStash;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _delay;

    public void Initialize(PlayerShip player) => _factory.Initialize(player, _bulletContainer);

    public void StartSpawning() => StartCoroutine(GetDelayed());

    public override Enemy Get(Vector2 position)
    {
        Enemy newEnemy;

        if (FreeObjects.Count == 0)
        {
            newEnemy = _factory.Produce();
            newEnemy.Died += Release;

            newEnemy.transform.SetParent(_enemyContainer.transform);
            AllObjects.Add(newEnemy);
            FreeObjects.Enqueue(newEnemy);
        }

        newEnemy = FreeObjects.Dequeue();
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

    public void Reset()
    {
        foreach (Enemy enemy in AllObjects)
        {
            if (FreeObjects.Contains(enemy) == false)
            {
                enemy.Die();
            }
        }
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
