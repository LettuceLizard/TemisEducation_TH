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
    public GameObject inputField;
    bool wordFound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Checks if the box exists and if the player input and the right letter match
    void BoxCheck(string rLetter, float number)
    {
        //resets wordfound before the next box is checked
        wordFound = false;
        //Finds the right box and saves the players input
        pLetter = GameObject.Find("Box" + number).GetComponent<Text>().text;
        
        //if it didn't find the box nothing happens
        if (pLetter != null)
        {
            //Converts both the player input and the right letter to uppercase which eliminates casesensitivity
            pLetter.ToUpper();
            rLetter.ToUpper();
            
            //Compares player input to the right letter
            //If they are the same bool wordFound is set to true
            if (rLetter == pLetter)
            {
                wordFound = true;
            }
        }
    }

    //moves the selected box either to the side or downwards depending on if the current word is a vertical or a horisontal word
    void BoxMover()
    {
        //check if selected box can move to the side, if not then don't move
            //move selected box to the side
        
        //check if selected box can move down, if not then don't move
            //move selected box down
    }
}