using System.Collections;
using UnityEngine;

public class AlienMovement : MonoBehaviour, IEnemyMoveable
{
    private float _moveSpeed;
    private Coroutine _coroutine;

    public void Initialize(float moveSpeed) => _moveSpeed = moveSpeed;

    public void Move(Vector2 target)
    {
        StopMoving();

        _coroutine = StartCoroutine(MoveSmoothly(target));
    }

    public void StopMoving()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator MoveSmoothly(Vector3 target)
    {
        while (transform.position != target)
        {
            transform.position = Vector2.Lerp(transform.position, target, Time.deltaTime * _moveSpeed);
            yield return null;
        }

        _coroutine = null;
    }
}
