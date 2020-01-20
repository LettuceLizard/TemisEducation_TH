using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    private string playerAnswer;    //reads the players answer through the inputfield
    public float timer = 2f;    //next leveltimer
    public GameObject inputField;   //reference to the inputfield
    public Text text;   //reference to the text that displays that you entered the wrong answer
    public GameObject victory;  //the victory image
    
    public void Answer(string rightAnswer)  //takes in the right answer from the inspector
    {
        playerAnswer = inputField.GetComponent<Text>().text;    //reads the players answer
        
        //converts both the strings to uppercase, which removes upper/lowercasesensitivity
        playerAnswer = playerAnswer.ToUpper();
        rightAnswer = rightAnswer.ToUpper();

        //if the player answered right it shows the victory image and loads the next scene after x seconds, int timer = x
        if(playerAnswer == rightAnswer)
        {
            //victory.SetActive(true);
            Invoke("NextLevel", timer);
        }
        //if the player answers incorrectly it asks the player to try again
        else
        {
            text.text = "Wrong answer, try again";
        }
        
    }

    //loads the next level trough the gamemanager
    void NextLevel()
    {
        FindObjectOfType<GameManager>().NextLevel();
    }
}