using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GridManagerTwoPointOh : MonoBehaviour
{
    private char[,] wordsChar = new char[ 10, 10]
    {
        { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'},
        { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'},
        { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'},
        { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'},
        { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'},
        { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'},
        { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'},
        { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'},
        { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'},
        { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'}
    };
    private bool[] wordsBool1 = { false, false, false, false, false, false, false, false, false, false};
    private bool[] wordsBool2 = { false, false, false, false, false, false, false, false, false, false};
    private bool[] wordsBool3 = { false, false, false, false, false, false, false, false, false, false};
    private bool[] wordsBool4 = { false, false, false, false, false, false, false, false, false, false};
    private bool[] wordsBool5 = { false, false, false, false, false, false, false, false, false, false};
    private bool[] wordsBool6 = { false, false, false, false, false, false, false, false, false, false};
    private bool[] wordsBool7 = { false, false, false, false, false, false, false, false, false, false};
    private bool[] wordsBool8 = { false, false, false, false, false, false, false, false, false, false};
    private bool[] wordsBool9 = { false, false, false, false, false, false, false, false, false, false};
    private bool[] wordsBool10 = { false, false, false, false, false, false, false, false, false, false};


    // Start is called before the first frame update
    public void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("field 1 : " + wordsBool1[i] + ", " + wordsBool1[i] + ", " + wordsBool1[i] + ", " + wordsBool1[i] + ", " + wordsBool1[i] + ", " + wordsBool1[i] + ", " + wordsBool1[i] + ", " + wordsBool1[i] + ", " + wordsBool1[i] + ", " + wordsBool1[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
    public void Entry(string position)
    {

        GameObject obj = EventSystem.current.currentSelectedGameObject;
        char input = obj.GetComponent<InputField>().text.ElementAt(0);
        
        if (position.Length == 2)
        {
            try
            {
                int.Parse(position);
            }
            catch (FormatException)
            {
                Debug.Log("word position string must contain only integers");
                throw;
            }

            string positionWordString = position.Substring( 0, 1);
            string positionLetterString = position.Substring( 1, 1);
        
            int positionWord = int.Parse(positionWordString);
            int positionLetter = int.Parse(positionLetterString);

            CheckIfRight( positionWord, positionLetter, input);
        }
        else
        {
            Debug.Log("word position string must be two letters long");
        }
    }

    private void CheckIfRight(int row, int coloumn, char input)
    {
        if (wordsChar[ row, coloumn] == input)
        {
            wordsBool[ row, coloumn] = true;
        }
    }
*/
}
