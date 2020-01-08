using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    // \/ what to do \/

    //crossword manager reference
    //preexisting grid with decided words

    //check selected box for the input letter
    //check if selected word is horisontal or not
    //move selected box to the side or down depending on if current word is vertical or horisontal

    string pLetter;
    int integer;
    int deci;
    double temp;
    public GameObject inputField;
    
    //uneven numbered words are horizontal, even are vertical
    List<bool> word1 = new List<bool>();
    List<bool> word2 = new List<bool>();
    List<bool> word3 = new List<bool>();
    //List<bool> word4 = new List<bool>();
    //...
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Checks if the box exists and if the player input and the right letter match
    public void BoxCheck(string rLetter, float number)
    {
        //Finds the right box and saves the players input
        inputField = GameObject.Find("Box" + number);
        pLetter = inputField.GetComponent<Text>().text;
        PlayerPrefs.SetFloat("number", number);
        //if it didn't find the box nothing will happen
        if (pLetter != null)
        {
            //Converts both the player input and the right letter to uppercase which eliminates casesensitivity
            pLetter.ToUpper();
            rLetter.ToUpper();
            
            //Compares player input to the right letter
            //If they are the same bool wordFound is set to true
            if (rLetter == pLetter)
            {
                inputField = null;
                pLetter = null;
                
                integer = (int) number;
                temp = (number - integer) * 10;
                deci = (int) temp;
                
                if (integer == 1)
                    word1.Insert(deci, true);
                
                else if (integer == 2)
                    word2.Insert(deci, true);
                
                else if (integer == 3)
                    word3.Insert(deci, true);
            }
        }
    }

    //selects the next box of the word
    void BoxMover()
    {
        //imports the float variable number from the BoxCheck method
        float number = PlayerPrefs.GetFloat("number") + 0.1f;
        //tries to find the next box of the same word
        inputField = GameObject.Find("Box" + number);

        //if it didn't find the box nothing will happen
        if (inputField != null)
        {
            //selects the next box
            inputField.GetComponent<InputField>().Select();
            inputField = null;
        }
    }

    //allows the user to check for errors
    public void ErrorCheck()
    {
        int a = 1;
        //prints each letter for each word to the debug console
        foreach (bool value in word1)
        {
            Debug.Log("Letter " + a + " in word 1 is: " + value);
            a++;
        }

        foreach (bool value in word2)
        {
            Debug.Log("Letter " + a + " in word 2 is: " + value);
            a++;
        }

        foreach (bool value in word3)
        {
            Debug.Log("Letter " + a + " in word 3 is: " + value);
            a++;
        }
    }
}