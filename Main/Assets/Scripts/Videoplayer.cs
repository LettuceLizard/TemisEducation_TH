using UnityEngine;
using UnityEngine.Video;

public class Videoplayer : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.Play();
    }

    void Update()
    {
        if (!videoPlayer.isPlaying)
        {
            Paused();
        }
    }

    void Paused()
    {
        int paused = PlayerPrefs.GetInt("paused");
        if (paused == 0)
        {
            FindObjectOfType<GameManager>().NextLevel();
        }
    }

    public void Stop()
    {
        PlayerPrefs.SetInt("paused", 1);
        videoPlayer.Pause();
    }

    public void Play()
    {
        PlayerPrefs.SetInt("paused", 0);
        videoPlayer.Play();
    }
}