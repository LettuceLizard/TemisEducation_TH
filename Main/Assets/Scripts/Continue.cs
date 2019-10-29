using UnityEngine;
using UnityEngine.SceneManagement;
public class Continue : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2;

    void Start()
    {
        int load = PlayerPrefs.GetInt("savedLevel");
        if (load >= 1)
        {
            panel.gameObject.SetActive(false);
            panel2.gameObject.SetActive(true);
            Debug.Log("it should work");
        }
        Debug.Log("But this works??");
    }

    public void ResetSave()
    {
        PlayerPrefs.SetInt("savedLevel", 0);
        SceneManager.LoadScene(0);
    }
}
