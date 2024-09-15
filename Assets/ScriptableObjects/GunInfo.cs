using UnityEngine;

[CreateAssetMenu(menuName = "New Gun")]
public class GunInfo : ScriptableObject
{
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _shootForce;
    [SerializeField] private int _damage;
    [SerializeField] private Bullet _bullet;

    public float ShootForce => _shootForce;
    public float ReloadTime => _reloadTime;
    public int Damage => _damage; 
    public Bullet Bullet => _bullet;
}
