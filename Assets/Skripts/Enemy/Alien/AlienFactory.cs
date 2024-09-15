using Unity.VisualScripting;
using UnityEngine;

public class AlienFactory : EnemyFactory
{
    [SerializeField] private Alien _alienPrefab;
    [SerializeField] private Gun _gunPrefab;
    [SerializeField] private float _startShootDelay;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _maxHealth;

    private PlayerShip _player;
    private BulletContainer _bulletContainer;

    public override void Initialize(PlayerShip player, BulletContainer container)
    {
        _player = player;
        _bulletContainer = container;
    }

    public override Enemy Produce()
    {
        Alien alien = Instantiate(_alienPrefab);
        Gun gun = Instantiate(_gunPrefab);

        var movement = alien.AddComponent<AlienMovement>();
        var shooter = alien.AddComponent<AlienShooter>();

        movement.Initialize(_moveSpeed);
        gun.Initialize(_bulletContainer);
        shooter.Initialize(gun, _startShootDelay);
        alien.Initialize(_maxHealth, _player, movement, shooter);

        return alien;
    }
}
