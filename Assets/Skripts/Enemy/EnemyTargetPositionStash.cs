using System.Linq;
using UnityEngine;

public class EnemyTargetPositionStash : MonoBehaviour
{
    [SerializeField] private EnemyTargetPosition[] _positions;

    public bool TryGetFreePosition(out Vector2 position)
    {
        EnemyTargetPosition[] freePositions = _positions.Where(position => position.IsBusy == false).ToArray();

        if (freePositions.Length == 0)
        {
            position = Vector2.zero;
        }
        else
        {
            int randomIndex = Random.Range(0, freePositions.Length);

            position = freePositions[randomIndex].transform.position;
        }

        return freePositions.Length > 0;
    }
}
