using UnityEngine;

public class ButtonHiding : MonoBehaviour
{
    private GameObject button;
    public void HideButton()
    {
        int index = PlayerPrefs.GetInt("buttonIndex") - 32;
        char indexAsChar = System.Convert.ToChar(index);
        string indexAsString = System.Convert.ToString(indexAsChar);

        button = GameObject.Find(indexAsString);
        button.gameObject.SetActive(false);
    }
}