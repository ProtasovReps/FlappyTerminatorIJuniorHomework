using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    public abstract void Initialize(PlayerShip player, BulletContainer container);

    public abstract Enemy Produce();
}