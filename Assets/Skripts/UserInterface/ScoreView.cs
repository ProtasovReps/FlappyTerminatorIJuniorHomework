using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Animator _animator;

    private Score _score;

    private void OnEnable()
    {
        if (_score != null)
            _score.ValueChanged += Display;
    }

    private void OnDisable()
    {
        _score.ValueChanged -= Display;
    }

    public void Initialize(Score score)
    {
        _score = score;
        _score.ValueChanged += Display;
    }

    private void Display()
    {
        _animator.SetTrigger(AnimatorConstants.ScoreIncreased);
        _text.text = _score.Value.ToString();
    }
}
