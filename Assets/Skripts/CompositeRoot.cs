using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private PlayerShipFactory _playerFactory;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private UserInterface _interface;
    [SerializeField] private CameraEffector _cameraEffector;
    [SerializeField] private GameRestarter _restarter;

    private void Start()
    {
        PlayerShip player = _playerFactory.Produce();

        _cameraEffector.Initialize(player);
        _enemyPool.Initialize(player);
        _restarter.Initialize(player, _enemyPool);
        _interface.Initialize(player, _enemyPool);
        _enemyPool.StartSpawning();
    }
}
