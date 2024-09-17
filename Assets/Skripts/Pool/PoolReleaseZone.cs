using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PoolReleaseZone : MonoBehaviour
{
    private void Awake() => GetComponent<Collider2D>().isTrigger = true;
}
