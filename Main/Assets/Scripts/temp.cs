using UnityEngine;
using System.Collections;
using Vuforia;
using UnityEngine.Video;

public class temp : MonoBehaviour, ITrackableEventHandler {
	
	private TrackableBehaviour mTrackableBehaviour;
	
    public VideoPlayer video;
	private bool mShowGUIButton = false;

    public float timer = 2f;
	private Rect mButtonRect = new Rect(50,50,120,60);
	
	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        video.enabled = false;
	}
	
	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED)
        {
            mShowGUIButton = true;
        }
        else
        {
            mShowGUIButton = false;
        }
    }
	
	void OnGUI() {
		if (mShowGUIButton == true) 
        {
            video.enabled = true;
            Invoke("NextLevelTimer", timer);
			// draw the GUI button
			if (GUI.Button(mButtonRect, "Hello")) {
				Debug.Log("Hello!");
			}
		}
	}

    void NextLevelTimer()
    {
        FindObjectOfType<GameManager>().NextLevel();
    }
}