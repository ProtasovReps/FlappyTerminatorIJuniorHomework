using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private Screen _endGameScreen;
    [SerializeField] private Screen _startScreen;

    private Score _score;
    private PlayerShip _playerShip;

    private void OnEnable()
    {
        if (_playerShip != null)
            _playerShip.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _playerShip.Died -= OnPlayerDied;
    }

    public void Initialize(PlayerShip player, EnemyPool enemyPool)
    {
        _score = new Score(enemyPool);
        _playerShip = player;
        _playerShip.Died += OnPlayerDied;

        _scoreView.Initialize(_score);
        _startScreen.Appear();
    }

    private void OnPlayerDied()
    {
        _endGameScreen.Appear();
        _score.Reset();
    }
}
