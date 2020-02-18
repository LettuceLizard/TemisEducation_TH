using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScaler : MonoBehaviour
{
    public GameObject map;
    Resolution res;
    double ratio;
    double newHeight;
    public Canvas canvas;

    // Start is called before the first frame update
    public void Start()
    {
        PlayerPrefs.SetFloat("scale", canvas.scaleFactor);

        res = Screen.currentResolution;

        //map dimensions is: 1146 x 2512
        //the goal is to set the width of the map to be equal to the width of the players resolution while maintaining the width x height ratio for the map
        ratio = 1146d / 2512d;
        //Debug.Log("ratio: " + ratio);
        newHeight = res.width / ratio;
        //Debug.Log("new height: " + newHeight);

        map.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, canvas.GetComponent<RectTransform>().rect.width);
        map.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, canvas.GetComponent<RectTransform>().rect.height);
    }
}