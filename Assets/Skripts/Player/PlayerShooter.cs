using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    
    private Gun _gun;

    private void OnEnable() => _inputReader.ShootKeyPressed += OnShootKeyPreseed;

    private void OnDisable() => _inputReader.ShootKeyPressed -= OnShootKeyPreseed;

    public void Initialize(Gun gun)
    {
        _gun = gun;

        gun.transform.position = transform.position;
        gun.transform.parent = transform;
    }

    private void OnShootKeyPreseed() => _gun.Shoot();
}
