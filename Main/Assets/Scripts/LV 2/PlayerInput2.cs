using UnityEngine;
using UnityEngine.UI;

public class PlayerInput2 : MonoBehaviour
{
    private string playerAnswer;
    public GameObject inputField;
    public Text textDisplay;
    private string rightAnswer = "Blackbeard";

    public void Answer()
    {
        playerAnswer = inputField.GetComponent<Text>().text;

        if(playerAnswer == rightAnswer)
        {
            textDisplay.text = "Correct answer, good job!";
            FindObjectOfType<GameManager>().NextLevel();
        }

        else
        {
            textDisplay.text = "Wrong answer, try again";
        }
    }
}