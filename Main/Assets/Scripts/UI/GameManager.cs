using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float timer = 2f;
    bool loading = false;
    //lets ypou continue from the scene you stopped playing on
    public void ContinueGame()
    {
        int load = PlayerPrefs.GetInt("savedLevel");
        SceneManager.LoadScene(load);
    }

    //loads te next level after it saves that you completed the current one so that ContinueGame() loads you on the next level
    public void NextLevel()
    {
        if (loading)
            return;
        else
            StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        loading = true;
        yield return new WaitForSeconds(timer);

        PlayerPrefs.SetInt("savedLevel", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        loading = false;
    }

    //quits the game
    public void QuitGame()
    {
        Application.Quit();
    }

    //loads the current scene
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //loads the previous scene
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}