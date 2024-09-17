using System.Collections;
using UnityEngine;

public class Blaster : Gun
{
    [SerializeField] private AudioSource _shootSound;

    private WaitForSeconds _reloadTime;
    private Coroutine _coroutine;

    private void Awake() => _reloadTime = new WaitForSeconds(ReloadTime);

    public override void Shoot()
    {
        if (_coroutine == null)
        {
            Bullet bullet = BulletPool.Get(transform.position);

            bullet.transform.right = transform.right;
            bullet.Rigidbody.AddForce(transform.right * ShootForce);
            _shootSound.pitch = Random.value;
            _shootSound.Play();
            Reload();
        }
    }

    public override void StopShooting()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    protected override void Reload() => _coroutine = StartCoroutine(ReloadDelayed());

    private IEnumerator ReloadDelayed()
    {
        yield return _reloadTime;
        _coroutine = null;
    }
}
