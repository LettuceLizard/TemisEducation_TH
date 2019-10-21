using UnityEngine;
using UnityEngine.UI;
public class cool : MonoBehaviour
{
    public GameObject Panel;
    public void hidePanel()
    {
        Panel.gameObject.SetActive(false);
    }
}