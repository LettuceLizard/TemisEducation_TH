using UnityEngine;
using UnityEngine.SceneManagement;
public class Continue : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2;

    void Start()
    {
        if (PlayerPrefs.GetInt("savedLevel") >= 1)
        {
            panel.gameObject.SetActive(false);
            panel2.gameObject.SetActive(true);
        }
    }

    public void ResetSave()
    {
        PlayerPrefs.SetInt("savedLevel", 0);
        SceneManager.LoadScene(0);
    }
}
