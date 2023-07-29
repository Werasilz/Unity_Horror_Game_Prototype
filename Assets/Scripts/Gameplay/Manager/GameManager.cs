using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SceneSingleton<GameManager>
{
    [Header("Game State")]
    public GameState currentGameState;

    [Header("Game Over GUI")]
    [SerializeField] private GameObject gameOverWindow;

    [Header("Gameplay Flag")]
    public bool canCrouch;
    public bool canSprint;

    private void Start()
    {
        currentGameState = GameState.Gameplay;
        canCrouch = false;
        canSprint = false;

        PlayerControllerInputAction.Instance.HideCursor(true);
    }

    public void CanCrouch(bool value)
    {
        canCrouch = value;
    }

    public void CanSprint(bool value)
    {
        canSprint = value;
    }

    public void GameOver()
    {
        currentGameState = GameState.GameOver;
        gameOverWindow.SetActive(true);
        PlayerControllerInputAction.Instance.HideCursor(false);
    }

    public void Restart(int sceneIndex)
    {
        LoadLevel(sceneIndex);
    }

    public void LoadLevel(int sceneIndex)
    {
        PlayerControllerInputAction.Instance.HideCursor(false);
        SceneManager.LoadScene(sceneIndex);
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
