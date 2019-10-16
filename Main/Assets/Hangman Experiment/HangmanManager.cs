using UnityEngine;

public class HangmanManager : MonoBehaviour
{
    public GameObject letter;
    
    void Start()
    {
        initLetters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void initLetters()
    {
 
        int nbletters = 5;
 
        for (int i = 0; i < nbletters; i++) 
        {
            Vector3 newPosition;
            newPosition = new Vector3 (transform.position.x + (i * 100), transform.position.y, transform.position.z);
            GameObject l = (GameObject)Instantiate (letter, newPosition, Quaternion.identity);
            l.name = "letter" + (i + 1);
            l.transform.SetParent(GameObject.Find ("Canvas").transform);
        }
    }
}
