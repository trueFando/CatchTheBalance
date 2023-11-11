using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLauncher : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private CookRotator _cookRotator;
    [SerializeField] private Spawner _miniballsSpawner;
    [SerializeField] private Spawner _bombSpawner;
    [SerializeField] private Spawner _trailsSpawner;
    [SerializeField] private ScoreKeeper _scoreKeeper;
    [SerializeField] private CookEmotions _emotions;
    [SerializeField] private GameOver _gameOver;

    [Header("UI")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Text _holdText;
    [SerializeField] private Canvas _gameOverCanvas;

    private Rigidbody2D _foodRb;

    private void Start()
    {
        _foodRb = FindObjectOfType<Food>().GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }

    public void Launch()
    {
        // скрыть UI
        _playButton.gameObject.SetActive(false);
        _holdText.gameObject.SetActive(false);

        // активировать управление 
        _cookRotator.Activate();

        // запустить еду
        _foodRb.gravityScale = 1f;

        // запустить падающие трейлы
        _trailsSpawner.StartSpawning();

        // запустить шарики
        _miniballsSpawner.StartSpawning();

        // запустить бомбы
        _bombSpawner.StartSpawning();

        _scoreKeeper.StartScoring();
    }

    public void OnGameOver()
    {
        _emotions.IsLooser = true;
        Invoke(nameof(GameOver), 1f);
    }

    private void GameOver()
    {
        _gameOverCanvas.gameObject.SetActive(true);
        Pause();
        _gameOver.OnGameOver();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
    }
}
