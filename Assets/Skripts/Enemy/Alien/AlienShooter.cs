using System.Collections;
using UnityEngine;

public class AlienShooter : MonoBehaviour, IEnemyShootable
{
    private Gun _gun;
    private Coroutine _coroutine;
    private WaitForSeconds _delay;

    public void Initialize(Gun gun, float startDelay)
    {
        _delay = new WaitForSeconds(startDelay);
        _gun = gun;

        gun.transform.SetPositionAndRotation(transform.position, transform.rotation);
        gun.transform.SetParent(transform);
    }

    public void Shoot()
    {
        _coroutine = StartCoroutine(ShootConstantly());
    }

    public void StopShooting()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _gun.StopShooting();
        }
    }

    private IEnumerator ShootConstantly()
    {
        yield return _delay;

        while (enabled)
        {
            _gun.Shoot();
            yield return null;
        }
    }
}
