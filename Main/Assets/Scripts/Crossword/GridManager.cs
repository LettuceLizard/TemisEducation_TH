using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GridManager : MonoBehaviour
{
    string pLetter; //player input
    string temp;    //temporary string used for importing of numbers
    int valueWordH, valueLetterH, valueWordV, valueLetterV; //variables used for math
    public Text text;   //the text element that is used to tell the player if there are errors

    //uneven numbered words are horizontal, even numbered words are vertical
    bool[] word1 = new bool[5];    //the number of spaces in the vector should match the amount of letters in the words
    string rWord1 = "";    //no spaces, the code can't handle it yet
    bool[] word2 = new bool[10];    //the number of spaces in the vector should match the amount of letters in the words  *
    string rWord2 = "";    //no spaces, the code can't handle it yet
    bool[] word3 = new bool[10];    //the number of spaces in the vector should match the amount of letters in the words  *
    string rWord3 = "";    //no spaces, the code can't handle it yet
    bool[] word4 = new bool[10];    //the number of spaces in the vector should match the amount of letters in the words  *
    string rWord4 = "";    //no spaces, the code can't handle it yet
    //...

    void Start()
    {
        rWord1 = rWord1.ToUpper();   //removes capsensitivity
        rWord2 = rWord2.ToUpper();   //removes capsensitivity
        rWord3 = rWord3.ToUpper();   //removes capsensitivity
        rWord4 = rWord4.ToUpper();   //removes capsensitivity
        Debug.Log(rWord1.ElementAt(0));
    }

    public void BoxCheck(string values) //format of string must follow "ABCD" where A = # of vertical word, B position of letter in vertical word, C = # of horizontal word, D = position of letter in horizontal word. For example, this is what the third letter of the second words string would look like: "0023"
    {
        //reads what object is selected
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        
        //gates the code so it will only run if the selected gameobject is an inputfield
        if (obj != null && obj.GetComponent<InputField>() != null)
        {
            pLetter = obj.GetComponent<InputField>().text;  //reads the players input
            pLetter = pLetter.ToUpper();  //removes capsensitivity

            //feeds the values given from the inputfield into the input array
            //and calculates where to input true or false in the boolean arrays
            temp = values.Substring(0, 1);
            valueWordH = sbyte.Parse(temp);

            temp = values.Substring(1, 1);
            valueLetterH = sbyte.Parse(temp) - 1;
            
            //feeds the values given from the inputfield into the input array
            //and "calculates" where to input true or false in the boolean arrays
            temp = values.Substring(2, 1);
            valueWordV = sbyte.Parse(temp) - 1;

            temp = values.Substring(3, 1);
            valueLetterV = sbyte.Parse(temp);

            //if string contains x letter then remove it and add a "true" value to the word

            if (valueWordH == 1)    //checks which word it is, 1 = word 1, 2 = word 2 and so on
            {
                Debug.Log("Word found");
                if (rWord1.ElementAt(valueLetterH) == pLetter.ElementAt(0))  //checks if the word contains the input letter
                {
                    Debug.Log("Letter found");
                    word1.SetValue(true, valueLetterH); //sets the value to "true"
                }

                else
                {
                    Debug.Log("Error: Input letter not found in array");
                    word1.SetValue(false, valueLetterH);    //sets the value to "false"
                    
                }
            }

            if (valueWordH == 3)    //checks which word it is, 1 = word 1, 2 = word 2 and so on
            {
                if (rWord3.ElementAt(valueLetterH) == pLetter.ElementAt(0))   //checks if the word contains the input letter
                {
                    word3.SetValue(true, valueLetterH); //sets the value to "true"
                }

                else
                {
                    word3.SetValue(false, valueLetterH);    //sets the value to "false"
                }
            }
            
            if (valueWordV == 2)    //checks which word it is, 1 = word 1, 2 = word 2 and so on
            {
                if (rWord2.ElementAt(valueLetterH) == pLetter.ElementAt(0))   //checks if the word contains the input letter
                {
                    word2.SetValue(true, valueLetterV); //sets the value to "true"
                }

                else
                {
                    word2.SetValue(false, valueLetterV);    //sets the value to "false"
                }
            }
            
            if (valueWordV == 4)    //checks which word it is, 1 = word 1, 2 = word 2 and so on
            {
                if (rWord4.ElementAt(valueLetterH) == pLetter.ElementAt(0))   //checks if the word contains the input letter
                {   
                    word4.SetValue(true, valueLetterV); //sets the value to "true"
                }

                else
                {
                    word4.SetValue(false, valueLetterV);    //sets the value to "false"
                }
            }
        }
        else
            Debug.Log("the selected gameobject was not an inputfield");
    }

    //allows the user to check for errors
    public void ErrorCheck()
    {
        int i = 1;
        foreach (bool value in word1)
        {
            Debug.Log("value " + i + " is: " + value);
            i++;
        }
        //checks each word if all values are true and saves them in a new array to allow me to check all the words for errors at once
        bool firstWord = (!word1.Contains(false));
        bool secondWord = (!word2.Contains(false));
        bool thirdWord = (!word3.Contains(false));
        bool fourthWord = (!word4.Contains(false));
        
        bool[] errors = new bool[4] {firstWord, secondWord, thirdWord , fourthWord};

        //if the array errors contain no false values
        if (!errors.Contains(false))
        {
            text.text = "Congratulations! all words are entered correct";
            FindObjectOfType<GameManager>().NextLevel();
        }

        //if the array errors contain no true values
        else if (!errors.Contains(true))
            text.text = "All words contains atleast one wrong letter";

        //if the array errors contain both true and false values
        else if (errors.Contains(false))
            text.text = "Some, not all, words contain one or more wrong letters";
        
        //something has gone wrong if this code is run
        else
            text.text = "Something has gone wrong if you can se this";
    }
}