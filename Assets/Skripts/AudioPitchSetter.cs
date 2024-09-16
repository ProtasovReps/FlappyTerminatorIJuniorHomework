using UnityEngine;
using UnityEngine.Audio;

public class AudioPitchSetter : MonoBehaviour
{
    private const string AmbiencePitch = nameof(AmbiencePitch);

    [SerializeField] private AudioMixerGroup _audioGroup;
    [SerializeField, Range(0.1f, 1f)] private float _maxPitch;
    [SerializeField, Range(0.1f, 1f)] private float _minPitch;

    public void SetMaxPitch() => _audioGroup.audioMixer.SetFloat(AmbiencePitch, _maxPitch);

    public void SetMinPitch() => _audioGroup.audioMixer.SetFloat(AmbiencePitch, _minPitch);
}
