using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]
public class CameraEffector : MonoBehaviour
{
    [SerializeField] private float _maxFocus;
    [SerializeField] private float _minFocus;
    [SerializeField] private float _blurSpeed;
    [SerializeField] private PostProcessVolume _postProcessVolume;

    private DepthOfField _depthOfField;
    private IStatistics _health;
    private Coroutine _coroutine;

    private void Awake()
    {
        _postProcessVolume.profile.TryGetSettings(out _depthOfField);
    }

    private void OnEnable()
    {
        if (_health != null)
        {
            _health.ValueChanged += PlayHitEffect;
        }
    }

    private void OnDisable()
    {
        _health.ValueChanged -= PlayHitEffect;
    }

    public void Initialize(PlayerShip player)
    {
        _health = player.HealthStat;
        _health.ValueChanged += PlayHitEffect;
    }

    private void PlayHitEffect()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(BlurSmoothly());
    }

    private IEnumerator BlurSmoothly()
    {
        while (_depthOfField.focusDistance > _minFocus)
        {
            _depthOfField.focusDistance.value = Mathf.MoveTowards(_depthOfField.focusDistance, _minFocus, _blurSpeed * Time.deltaTime);
            yield return null;
        }

        yield return StartCoroutine(UnblurSmoothly());
    }

    private IEnumerator UnblurSmoothly()
    {
        while (_depthOfField.focusDistance < _maxFocus)
        {
            _depthOfField.focusDistance.value = Mathf.MoveTowards(_depthOfField.focusDistance, _maxFocus, _blurSpeed * Time.deltaTime);
            yield return null;
        }

        _coroutine = null;
    }
}
