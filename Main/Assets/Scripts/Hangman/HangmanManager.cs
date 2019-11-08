using UnityEngine;
using UnityEngine.UI;

public class HangmanManager : MonoBehaviour
{
    private int truelength;
    private int n = 0;
    private int j = 0;
    private int nbletters;
    private char letterPressedAsChar;
    private bool wordFound;
    private bool found;
    public string wordToGuess;
    Vector3 newPosition;
    private GameObject center;
    public GameObject pad;

    void Start()
    {
        center = GameObject.Find("centerOfScreen");
        SetupGame();
        SetupLayout();
    }

    void SetupGame()
    {
        wordToGuess = wordToGuess.ToUpper();
        char[] word = new char [wordToGuess.Length];

        for (int i = 0; i < wordToGuess.Length; i++)
        {
            found = false;

            if (wordToGuess[i] == ' ')
            {
                i++;
            }

            for (int k = 0; k < wordToGuess.Length; k++)
            {
                if (word[k] == wordToGuess[i])
                {
                    found = true;
                }
            }

            if (!found)
            {
                word.SetValue(wordToGuess[i], i);              
            }
        }
    }

    void SetupLayout()
    {
        nbletters = wordToGuess.Length;
 
        for (int i = 0; i < nbletters; i++) 
        {
            newPosition = new Vector3 (center.transform.position.x + (((i-nbletters/2.0f) *75)), center.transform.position.y, center.transform.position.z);
            GameObject l = (GameObject)Instantiate (pad, newPosition, Quaternion.identity);
            l.name = "letter" + (i + 1);
            l.transform.SetParent(GameObject.Find ("word").transform);

            if (wordToGuess[i] == ' ')
            {
                GameObject.Find("letter" + (i + 1)).SetActive(false);
            }
        }
    }

    public void Input(int letterPressedAsInt)
    {
        wordFound = false;
        PlayerPrefs.SetInt("buttonIndex", letterPressedAsInt);
        FindObjectOfType<ButtonHiding>().HideButton();
        letterPressedAsChar = System.Convert.ToChar(letterPressedAsInt);

        for (int i=0; i < wordToGuess.Length; i++)
        {
            letterPressedAsChar = System.Char.ToUpper(letterPressedAsChar);
            if (wordToGuess[i] == letterPressedAsChar)
            {
                GameObject.Find("letter" + (i + 1)).GetComponent<Text>().text = letterPressedAsChar.ToString();
                wordFound = true;
                n++;
            }
        }

        if (!wordFound)
        {
            GameObject.Find("Hangman" + j).GetComponent<Image>().enabled = false;
            j++;
        }

        if (j >= 10)
        {
            GameObject.Find("GameOver").SetActive(true);
        }

        if (n == truelength)
        {

        }
    }
}