using UnityEngine;

public class GameRestarter : MonoBehaviour
{
    private IScreen _endGameScreen;
    private UserInterface _userInterface;
    private PlayerShip _playerShip;
    private EnemyPool _enemyPool;
    private Score _score;

    private void OnEnable()
    {
        if (_playerShip != null)
            _playerShip.Died += OnPlayerDied;

        if (_endGameScreen != null)
            _endGameScreen.ButtonPressed += OnButtonPressed;
    }

    private void OnDisable()
    {
        _playerShip.Died -= OnPlayerDied;
        _endGameScreen.ButtonPressed -= OnButtonPressed;
    }

    public void Initialize(PlayerShip player, EnemyPool pool, UserInterface userInterface, Score score)
    {
        _playerShip = player;
        _enemyPool = pool;
        _userInterface = userInterface;
        _endGameScreen = userInterface.EndGameScreen;
        _score = score;

        _endGameScreen.ButtonPressed += OnButtonPressed;
        player.Died += OnPlayerDied;
    }

    private void OnPlayerDied() => _userInterface.AppearEndScreen();

    private void OnButtonPressed()
    {
        _playerShip.Reset();
        _enemyPool.Reset();
        _score.Reset();
    }
}
