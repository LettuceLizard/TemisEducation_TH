using UnityEngine;

public class ButtonHiding : MonoBehaviour
{
    private GameObject button;
    int index;
    char indexAsChar;
    string indexAsString;
    
    public void HideButton()
    {
        index = PlayerPrefs.GetInt("buttonIndex") - 32;
        indexAsChar = System.Convert.ToChar(index);
        indexAsString = System.Convert.ToString(indexAsChar);

        GameObject.Find(indexAsString).SetActive(false);
    }
}