using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GridManager : MonoBehaviour
{
    string pLetter; //player input
    int valueWordH; //variable used for math
    int valueLetterH;   //variable used for math
    int valueWordV; //variable used for math
    int valueLetterV;   //variable used for math
    public Text text;
    
    //uneven numbered words are horizontal, even numbered words are vertical
    bool[] word1 = new bool[10];    //word: *enter the word here*
    bool[] word2 = new bool[10];    //word: *enter the word here*
    bool[] word3 = new bool[10];    //word: *enter the word here*
    bool[] word4 = new bool[10];    //word: *enter the word here*
    //...
    double[] input = new double[2]; //values of the letters positions in both horizontal and vertical words

    //string rLetter = the right letter for the current box, double input1 is the position of the letter in a horizontal word and double input2 is the same but for vertical words
    public void BoxCheck(string rLetter, double wordPositionH, double wordPositionV)
    {
        //feeds the values given from the inputfield into the input array
        input.SetValue(wordPositionH, 0);
        input.SetValue(wordPositionV, 1);

        //Converts both the player input and the right letter to uppercase which eliminates casesensitivity
        pLetter.ToUpper();
        rLetter.ToUpper();

        //calculates where to input true or false in the bool arrays
        valueWordH = (int) input.GetValue(0);
        valueLetterH = ((int) input.GetValue(0) - valueWordH) * 10;

        valueWordV = (int) input.GetValue(0);
        valueLetterV = ((int) input.GetValue(0) - valueWordV) * 10;
       
        //Compares player input (pLetter) to the right letter (rLetter)
        if (rLetter == pLetter)
        {
            if (valueWordH == 1)
                word1.SetValue(true, valueLetterH);
            
            else if (valueWordH == 3)
                word3.SetValue(true, valueLetterH);
            
            if (valueWordV == 2)
                word2.SetValue(true, valueLetterV);
            
            else if (valueWordV == 4)
                word4.SetValue(true, valueLetterV);
            
            //something has gone wrong if this code is run
            else
                text.text = "Something has gone wrong if you can se this";
        }

        //if the player didn't input the right letter it saves here
        else if (rLetter != pLetter)
        {
            if (valueWordH == 1)
                word1.SetValue(false, valueLetterH);
            
            else if (valueWordH == 3)
                word3.SetValue(false, valueLetterH);
            
            if (valueWordV == 2)
                word2.SetValue(false, valueLetterV);
            
            else if (valueWordV == 4)
                word4.SetValue(false, valueLetterV);
            
            //something has gone wrong if this code is run
            else
                text.text = "Something has gone wrong if you can se this";
        }

        //something has gone wrong if this code is run
        else
            text.text = "Something has gone wrong if you can se this";
    }

    //allows the user to check for errors
    public void ErrorCheck()
    {
        //checks each word if all values are true and saves them in a new array ta simplify checking all words for errors at once
        bool firstWord = (!word1.Contains(false));
        bool secondWord = (!word2.Contains(false));
        bool thirdWord = (!word3.Contains(false));
        bool fourthWord = (!word4.Contains(false));
        bool[] errors = new bool[4] {firstWord, secondWord, thirdWord , fourthWord};

        //if the array errors contain no false values
        if (!errors.Contains(false))
        {
            text.text = "Congratolations! all words are entered correct";
            FindObjectOfType<GameManager>().NextLevel();
        }

        //if the array errors contain no true values
        else if (!errors.Contains(true))
            text.text = "All words contains atleast on wrong letter";

        //if the array errors contain both true and false values
        else if (errors.Contains(false))
            text.text = "Some, not all, words contain one or more wrong letters";
        
        //something has gone wrong if this code is run
        else
            text.text = "Something has gone wrong if you can se this";
    }
}