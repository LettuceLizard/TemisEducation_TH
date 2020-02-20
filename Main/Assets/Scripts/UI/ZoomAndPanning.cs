using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomAndPanning : MonoBehaviour
{
    Vector3 touchStart; 
    public Canvas canvas;   //reference to canvas
    public float zoomOutMin = -100f;    //min zoom
    public float zoomOutMax = 100f; //max zoom
	
	// Update is called once per frame
	void Update () 
    {    
        if(Input.GetMouseButtonDown(0))
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //reads two touches and finds the touchdelta and then uses that to zoom in or out
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            //difference is the delta of the two touch points
            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }
        
        else if(Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }

        zoom(Input.GetAxis("Mouse ScrollWheel"));   //temporary code that allows us to zoom on the computer
	}

    void zoom(float increment)
    {
        canvas.scaleFactor = Mathf.Clamp(canvas.scaleFactor - increment, zoomOutMin, zoomOutMax);
        //Debug.Log(canvas.scaleFactor);
    }

    public void resetZoom()
    {
        canvas.scaleFactor = PlayerPrefs.GetFloat("scale");
    }
}