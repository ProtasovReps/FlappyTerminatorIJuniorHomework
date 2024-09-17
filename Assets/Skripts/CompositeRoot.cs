using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private PlayerShipFactory _playerFactory;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private UserInterface _userInterface;
    [SerializeField] private GameRestarter _restarter;
    [SerializeField] private CameraEffector _cameraEffector;

    private void Start()
    {
        PlayerShip player = _playerFactory.Produce();
        var score = new Score(_enemyPool);

        _cameraEffector.Initialize(player);
        _enemyPool.Initialize(player);
        _userInterface.Initialize(_enemyPool, score);
        _restarter.Initialize(player, _enemyPool, _userInterface, score);
        _enemyPool.StartSpawning();
    }
}
