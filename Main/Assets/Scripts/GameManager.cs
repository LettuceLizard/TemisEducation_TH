using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    string currentScene;
    int i = 1;
    public float nextLevelTimer = 15f;

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