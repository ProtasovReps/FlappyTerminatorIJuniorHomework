using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    public abstract void Initialize(PlayerShip player, Container bulletContainer);

    public abstract Enemy Produce();
}