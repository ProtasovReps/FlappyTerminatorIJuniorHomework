using UnityEngine;

public class GameRestarter : MonoBehaviour
{
    private PlayerShip _playerShip;
    private EnemyPool _enemyPool;

    private void OnEnable()
    {
        if (_playerShip != null)
            _playerShip.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _playerShip.Died -= OnPlayerDied;
    }

    public void Initialize(PlayerShip player, EnemyPool pool)
    {
        _playerShip = player;
        _enemyPool = pool;
        player.Died += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        _playerShip.Reset();
        _enemyPool.Clear();
    }
}
