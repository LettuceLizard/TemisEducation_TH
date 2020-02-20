using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Continue : MonoBehaviour
{
    public GameObject start;
    public GameObject cont;
    public Text text;

    void Start()
    {
        if (PlayerPrefs.GetInt("savedLevel") >= 1)
        {
            start.gameObject.SetActive(false);
            cont.gameObject.SetActive(true);
        }
    }

    public void ResetSave()
    {
        PlayerPrefs.SetInt("savedLevel", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}