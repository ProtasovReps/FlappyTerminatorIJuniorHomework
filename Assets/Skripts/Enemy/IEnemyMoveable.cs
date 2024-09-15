using UnityEngine;

public interface IEnemyMoveable 
{
    public void Move(Vector2 targetPosition);

    public void StopMoving();
}
