using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    private string playerAnswer;
    public GameObject inputField;
    public GameObject textDisplay;
    private string rightAnswer = "Regalskeppet Vasa";

    public void Answer()
    {
        playerAnswer = inputField.GetComponent<Text>().text;

        if(playerAnswer == rightAnswer)
        {
            textDisplay.GetComponent<Text>().text = "You've answered the question correctly!";
            FindObjectOfType<GameManager>().NextLevel();
        }

        else
        {
            textDisplay.GetComponent<Text>().text = "That's the wrong answer, try again";
        }
    }
}