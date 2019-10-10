using UnityEngine;
using UnityEngine.Video;

public class Videoplayer : MonoBehaviour
{
    private VideoPlayer Video;
    void Start()
    {
        Video = GetComponent<VideoPlayer>();
        Video.enabled = false;
    }

    void Update()
    {
        Video.enabled = true;        
    }
}
