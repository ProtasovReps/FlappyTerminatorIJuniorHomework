using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioPitchSetter _pitchSetter;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
        _pitchSetter.SetMinPitch();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        _pitchSetter.SetMaxPitch();
    }

    public void Appear()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }

    private void OnButtonClick()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
