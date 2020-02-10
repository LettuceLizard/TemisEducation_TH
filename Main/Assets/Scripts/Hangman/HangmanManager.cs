using UnityEngine;
using UnityEngine.UI;

public class HangmanManager : MonoBehaviour
{
    private int j = 0;  //temporary integer used in loops
    private int n = 0;  //temporary integer used in loops
    private int p = 0;  //temporary integer used in loops
    private bool found; //temporary boolean used in loops
    private bool wordFound; //temporary boolean used in loops

    private int truelength; //length of wordToGuess without spaces or duplicate letters if there are any
    public string wordToGuess;  //the input word to guess
    private char letterPressedAsChar;   //input letter saved as char instead of as a string
    Vector3 newPosition;    //stores the positions of the paddles
    private GameObject center;  //aligns the pads to this center object
    public GameObject pad;  //reference to the pad to be used
    public GameObject underScore;   //reference to the pad to be used
    public float gameLostTimer = 5f;    //time until ReloadScene() is called
    public float gameWonTimer = 5f; //time until NextLevel() is called

    public GameObject victory;  //the victory image
    
    //runs the setup methods when scene is loaded
    void Start()
    {
        center = GameObject.Find("centerOfScreen"); //finds the game object named "centerofscreen" to align the new paddles to it later
        
        //runs the setup methods
        SetupGame();
        SetupLayout();
    }

    //finds the true length of the input word/words
    void SetupGame()
    {
        wordToGuess = wordToGuess.ToUpper();    //converts all letters to upper case letters
        char[] word = new char [wordToGuess.Length];

        for (int i = 0; i < wordToGuess.Length; i++)
        {
            found = false;

            if (wordToGuess[i] == ' ')
            {
                i++;
                p++;
            }

            for (int k = 0; k < wordToGuess.Length; k++)
            {
                if (word[k] == wordToGuess[i])
                {
                    found = true;
                    p++;
                }
            }

            if (!found)
            {
                word.SetValue(wordToGuess[i], i);              
            }
        }
        truelength = word.Length - p;
    }

    //sets up the layout of the paddles
    void SetupLayout()
    { 
        for (int i = 0; i < wordToGuess.Length; i++) 
        {
            //for each letter it finds it builds a paddle and aligns it to the centerofscreen object
            newPosition = new Vector3 (center.transform.position.x + (((i-wordToGuess.Length/2.0f) * 5)), center.transform.position.y, center.transform.position.z);
            GameObject l = (GameObject)Instantiate (underScore, newPosition, Quaternion.identity);
            l.name = "Lletter" + (i + 1);
            l.transform.SetParent(GameObject.Find ("word").transform);
            GameObject k = (GameObject)Instantiate (pad, newPosition, Quaternion.identity);
            k.name = "Kletter" + (i + 1);
            k.transform.SetParent(GameObject.Find ("word").transform);
            k.GetComponent<Text>().enabled = false;

            if (wordToGuess[i] == ' ')  //if there's a space is hides the paddle representing the space
            {
                GameObject.Find("Lletter" + (i + 1)).SetActive(false);
            }
        }
    }

    //checks the players input for matches in the word to guess and, if the input matches a letter, exchanges the paddle in the right place for the letter
    public void Input(int letterPressedAsInt)   //takes in the letter pressed as an integer
    {
        wordFound = false;
        PlayerPrefs.SetInt("buttonIndex", letterPressedAsInt);  //sets the letter pressed as an integer
        FindObjectOfType<ButtonHiding>().HideButton();  //calls the HideButton() method in the ButtonHiding script
        letterPressedAsChar = System.Convert.ToChar(letterPressedAsInt);

        for (int i=0; i < wordToGuess.Length; i++)
        {
            letterPressedAsChar = System.Char.ToUpper(letterPressedAsChar);

            if (wordToGuess[i] == letterPressedAsChar)
            {
                //GameObject.Find("letter" + (i + 1)).GetComponent<Text>().text = letterPressedAsChar.ToString();
                GameObject.Find("Lletter" + (i + 1)).GetComponent<Image>().enabled = false;
                GameObject.Find("Kletter" + (i + 1)).GetComponent<Text>().enabled = true;
                GameObject.Find("Kletter" + (i + 1)).GetComponent<Text>().text = letterPressedAsChar.ToString();
                wordFound = true;
            }
        }

        if (wordFound)  //hides/shows the hangman
        {
            GameObject.Find("Hangman" + n).GetComponent<Image>().enabled = true;
            n++;
        }

        else if (!wordFound)
            j++;

        if (j >= 11)
        {
            GameObject.Find("GameOver").GetComponent<Text>().enabled = true;
            Invoke("ReloadScene", gameLostTimer);
        }

        else if (n >= truelength)
        {
            victory.SetActive(true);
            GameObject.Find("GameWon").GetComponent<Text>().enabled = true;
            Invoke("NextLevel", gameWonTimer);
        }
    }

    //reloads scene, called if player loses
    void ReloadScene()
    {
        FindObjectOfType<GameManager>().ReloadScene();
    }

    //loads next scene, called if player wins
    void NextLevel()
    {
        FindObjectOfType<GameManager>().NextLevel();
    }
}