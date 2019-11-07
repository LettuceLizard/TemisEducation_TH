using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
//---------------------------------------------------//
//-------------Använd en dubbel for-loop-------------//
//---------------------------------------------------//
public class HangmanManager : MonoBehaviour
{
    public string wordToGuess;
    private int lengthOfWordToGuess;
    private GameObject center;
    public GameObject pad;
    Vector3 newPosition;
    private int nbletters;
    private char letterPressedAsChar;
    int n = 0;
    int j = 0;
    bool wordFound;
    int truelength;
    List<char> word = new List<char>();
    int temp;

    void Start()
    {
        center = GameObject.Find("centerOfScreen");
        SetupGame();
        SetupLayout();
    }

    void SetupGame()
    {
        lengthOfWordToGuess = wordToGuess.Length;
        wordToGuess = wordToGuess.ToUpper();

        for (int i = 0; i < lengthOfWordToGuess; i++)
        {
            word.Add(wordToGuess[i]);               
            Debug.Log(word.Count);
            Debug.Log(word[i]);
            //for (int k = 0; k < lengthOfWordToGuess; k++)
            //{
                
            //}
        }
    }

    void SetupLayout()
    {
        nbletters = lengthOfWordToGuess;
 
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

        for (int i=0; i < lengthOfWordToGuess; i++)
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