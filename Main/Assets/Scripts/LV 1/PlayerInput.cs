using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    private string playerAnswer;
    public GameObject inputField;
    public Text textDisplay;
    private string rightAnswer = "Regalskeppet Vasa";

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

    private void NextLevel()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}