using UnityEngine;
using UnityEngine.Video;

public class Videoplayer : MonoBehaviour
{
    public VideoPlayer Video;
    public GameObject Object;

    bool yeet = false;
    void Start()
    {
        
        Video.enabled = false;
    }

    void Update()
    {
        if (yeet == true)
        {
            Video.enabled = true;        
        }
    }
}