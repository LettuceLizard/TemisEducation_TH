using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class Videoplayer : MonoBehaviour
{
    private VideoPlayer Video;
    public ImageTargetBehaviour Target;
    void Start()
    {
        Video = GetComponent<VideoPlayer>();
        Video.enabled = false;
    }

    void Update()
    {
        if (Target == true)
        {
            Video.enabled = true;        
        }
    }
}
