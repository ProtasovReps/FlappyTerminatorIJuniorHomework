using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private Screen _endGameScreen;
    [SerializeField] private Screen _startScreen;

    public IScreen EndGameScreen => _endGameScreen;

    public void Initialize(EnemyPool enemyPool, Score score)
    {
        _scoreView.Initialize(score);
        _startScreen.Appear();
    }

    public void AppearEndScreen() => _endGameScreen.Appear();
}
