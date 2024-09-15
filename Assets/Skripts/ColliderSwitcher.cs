using System.Collections;
using UnityEngine;

public class ColliderSwitcher : MonoBehaviour
{
    [SerializeField] private float _colliderDisableTime;

    private IStatistics _statistics;
    private Collider2D _collider;
    private Coroutine _coroutine;
    private WaitForSeconds _delay;

    private void OnEnable()
    {
        if (_coroutine != null)
            _statistics.ValueChanged += SwitchCollider;
    }

    private void OnDisable()
    {
        _statistics.ValueChanged -= SwitchCollider;
    }

    public void Initialize(IStatistics statistics, Collider2D collider)
    {
        _delay = new WaitForSeconds(_colliderDisableTime);
        _collider = collider;
        _statistics = statistics;
        _statistics.ValueChanged += SwitchCollider;
    }

    public void SwitchCollider()
    {
        if(_coroutine == null)
            _coroutine = StartCoroutine(SwitchColliderSmoothly());
    }

    private IEnumerator SwitchColliderSmoothly()
    {
        _collider.enabled = false;
        yield return _delay;

        _collider.enabled = true;
        _coroutine = null;
    }
}
