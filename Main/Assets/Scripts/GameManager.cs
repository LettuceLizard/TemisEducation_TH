using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    string currentScene;
    int i = 1;
    public float nextLevelTimer = 15f;

    public void ContinueGame()
    {
        int load = PlayerPrefs.GetInt("savedLevel");
        SceneManager.LoadScene(load);
    }

    public void CompleteLevel()
    {
        Invoke("NextLevel", nextLevelTimer);
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("savedLevel", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        PlayerPrefs.SetInt("savedLevel", SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ShowMap()
    {   
        currentScene = SceneManager.GetActiveScene().name;    
        SceneManager.LoadScene("map");
    }
    /*
    public void Map()
    {
        i++;
        Debug.Log("i = " + i);
        Debug.Log("n = " + n);
        string previousScene = currentScene;
        currentScene = SceneManager.GetActiveScene().name;
        
        if (i == 3)
        {
            SceneManager.LoadScene(previousScene);
            Debug.Log(previousScene + " How are you?");   
        }

        if (currentScene != "map")
        {
            SceneManager.LoadScene("map");
            Debug.Log(currentScene + " Goodbye");
        }
        
        if (currentScene == "map" && i != 3)
        {
            SceneManager.LoadScene(previousScene);
            Debug.Log(previousScene + " Hello");
        }
    }
    */
}