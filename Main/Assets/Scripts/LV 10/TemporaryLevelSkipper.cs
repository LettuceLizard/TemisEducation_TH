using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryLevelSkipper : MonoBehaviour
{
    public void SkipLevel()
    {
        FindObjectOfType<GameManager>().NextLevel();
    }
}
