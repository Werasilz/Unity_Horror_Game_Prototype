using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Application.Quit();
        }
    }
}
