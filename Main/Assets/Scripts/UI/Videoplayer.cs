using UnityEngine;
using UnityEngine.Video;

public class Videoplayer : MonoBehaviour
{
    public VideoPlayer videoPlayer; //references the videoplayer
    public GameManager gameManager; //references the gamemanager
    int paused = 0; //integer that is used like a boolean to determine if the video is paused or not

    //makes sure the video is playing
    void Start()
    {
        videoPlayer.Play();
    }

    //checks if the video is playing every frame
    void Update()
    {
        //if the video is not playing the Paused() method is called
        if (!videoPlayer.isPlaying)
        {
            Paused();
            //Debug.Log("is paused");
        }
    }

    //skips to the next scene if the video isn't paused and isn't palying
    void Paused()
    {
        paused = PlayerPrefs.GetInt("paused");
        if (paused == 0)    //if paused = 0 the video isn't paused, if it equals 1 it is paused
        {
            //Debug.Log("is over");
            gameManager.NextLevel();
        }
    }

    //pauses the video and tells the script that the video is paused
    public void Stop()
    {
        PlayerPrefs.SetInt("paused", 1);
        videoPlayer.Pause();
    }

    //plays the video and tells the script that the video is no longer paused
    public void Play()
    {
        PlayerPrefs.SetInt("paused", 0);
        videoPlayer.Play();
    }
}