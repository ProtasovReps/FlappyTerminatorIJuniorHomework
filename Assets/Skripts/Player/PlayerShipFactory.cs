using UnityEngine;

public class PlayerShipFactory : MonoBehaviour
{
    [SerializeField] private PlayerShip _shipPrefab;
    [SerializeField] private Gun _gunPrefab;
    [SerializeField] private BulletContainer _bulletContainer;
    [SerializeField] private int _maxHealth;

    public PlayerShip Produce()
    {
        PlayerShip player = Instantiate(_shipPrefab);
        Gun gun = Instantiate(_gunPrefab);

        gun.Initialize(_bulletContainer);
        player.Initialize(gun, _maxHealth);
        return player;
    }
}
