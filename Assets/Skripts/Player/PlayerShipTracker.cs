using System.Collections;
using UnityEngine;

public class PlayerShipTracker : MonoBehaviour
{
    private PlayerShip _player;
    private Coroutine _coroutine;

    public void Initialize(PlayerShip player) => _player = player;

    public void StartTrack() => _coroutine = StartCoroutine(Track());

    public void StopTrack()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Track()
    {
        while (enabled)
        {
            Vector2 direction = _player.transform.position - transform.position;
            transform.right = direction;
            yield return null;
        }
    }
}
