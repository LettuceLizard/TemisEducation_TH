using UnityEngine;
using UnityEngine.SceneManagement;

public class Karta : MonoBehaviour
{
    public void OpenMap()
    {
        SceneManager.LoadScene("map");
    }

    public void CloseMap()
    {
        SceneManager.LoadScene("map");
    }
}
