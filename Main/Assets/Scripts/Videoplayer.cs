using UnityEngine;
using UnityEngine.Video;

public class Videoplayer : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameManager gameManager;

    void Start()
    {
        videoPlayer.Play();
    }

    void Update()
    {
        if (!videoPlayer.isPlaying)
        {
            Paused();
            Debug.Log("is paused");
        }
    }

    void Paused()
    {
        int paused = PlayerPrefs.GetInt("paused");
        if (paused == 0)
        {
            Debug.Log("is over");
            gameManager.NextLevel();
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