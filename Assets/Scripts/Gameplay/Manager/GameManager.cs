using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SceneSingleton<GameManager>
{
    [Header("Game State")]
    public GameState currentGameState;

    [Header("Game Over GUI")]
    [SerializeField] private GameObject gameOverWindow;

    private void Start()
    {
        currentGameState = GameState.Gameplay;
    }

    public void GameOver()
    {
        currentGameState = GameState.GameOver;
        gameOverWindow.SetActive(true);
        PlayerControllerInputAction.Instance.HideCursor(false);
    }

    public void Restart()
    {
        PlayerControllerInputAction.Instance.HideCursor(true);
        SceneManager.LoadScene(0);
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex == 0)
        {
            // Load the event and object from previous play
        }
    }
}
public enum GameState
{
    Loading,
    Gameplay,
    GameOver,
}
