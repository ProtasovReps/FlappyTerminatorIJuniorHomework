using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private PlayerShipFactory _playerFactory;
    [SerializeField] private CameraEffector _cameraEffector;
    [SerializeField] private EnemyPool _enemyPool;
    
    private void Start()
    {
        PlayerShip player = _playerFactory.Produce();
        
        _cameraEffector.Initialize(player);
        _enemyPool.Initialize(player);
        _enemyPool.StartSpawning();
    }
}
