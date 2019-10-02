using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<GameManager>().NextLevel();
    }
    public void QuitGame ()

    {
        Debug.Log("Quit");
        Application.Quit();
    }
}