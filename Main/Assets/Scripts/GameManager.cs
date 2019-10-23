using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float nextLevelTimer = 3;

    public void CompleteLevel()
    {
        Invoke("NextLevel", nextLevelTimer);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SaveScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.Log("hello");
    }

    public void ShowMap()
    {       
        SceneManager.LoadScene("map");
    }
    
    public void HAHAHAHA()
    {
        Invoke("HideMap", 0f);
    }
    public void HideMap(string loadThis = "currentScene")
    {
        SceneManager.LoadScene(loadThis);
    }
}