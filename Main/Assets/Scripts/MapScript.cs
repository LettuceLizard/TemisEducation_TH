﻿using UnityEngine;

public class MapScript : MonoBehaviour
{
    public int firstMapPiece;
    public int secondMapPiece;
    public GameObject blankMap;
    public GameObject halfMap;
    public GameObject fullMap;

    public void Map()
    {
        int index = PlayerPrefs.GetInt("savedLevel");
        
        if (index <= firstMapPiece)
        {
            blankMap.gameObject.SetActive(true);
        }

        else if (index > firstMapPiece && index <= secondMapPiece)
        {
            halfMap.gameObject.SetActive(true);
        }

        else if (index > secondMapPiece)
        {
            fullMap.gameObject.SetActive(true);
        }
    }
}