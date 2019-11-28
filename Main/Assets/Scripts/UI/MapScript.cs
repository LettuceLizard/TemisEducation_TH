using UnityEngine;
using UnityEngine.SceneManagement;
public class MapScript : MonoBehaviour
{
    int firstMapPiece = 10;
    int secondMapPiece = 21;
    public GameObject blankMap;
    public GameObject halfMap;
    public GameObject fullMap;

    public void Map()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        
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