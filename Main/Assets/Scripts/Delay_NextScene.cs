using UnityEngine;

public class Delay_NextScene : MonoBehaviour
{
    void Start()
    {
    
        FindObjectOfType<GameManager>().CompleteLevel();
    }

}
