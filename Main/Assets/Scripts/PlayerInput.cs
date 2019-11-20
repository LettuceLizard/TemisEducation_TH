using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    private string playerAnswer;
    public float timer = 2f;
    public GameObject inputField;
    //public TMPro.TextMeshProUGUI text;
    public Text text;
    
    public void Answer(string rightAnswer)
    {
        playerAnswer = inputField.GetComponent<Text>().text;
        
        playerAnswer = playerAnswer.ToUpper();
        rightAnswer = rightAnswer.ToUpper();

        if(playerAnswer == rightAnswer)
        {
            text.text = "Correct answer, good job!";
            Invoke("NextLevel", timer);
        }

        else
        {
            text.text = "Wrong answer, try again";
        }
    }

    void NextLevel()
    {
        FindObjectOfType<GameManager>().NextLevel();
    }
}