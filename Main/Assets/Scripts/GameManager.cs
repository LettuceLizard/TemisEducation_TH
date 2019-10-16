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
}