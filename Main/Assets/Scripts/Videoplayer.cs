using UnityEngine;
using UnityEngine.Video;

public class Videoplayer : MonoBehaviour
{
    public VideoPlayer video;
    public float length = 3f;

    void Start()
    {
        Invoke("NextScene",length);
    }

    private void NextScene()
    {
        FindObjectOfType<GameManager>().NextLevel();
    }
}