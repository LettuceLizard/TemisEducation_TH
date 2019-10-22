using UnityEngine;
public class cool : MonoBehaviour
{
    public GameObject Panel;
    public void hidePanel()
    {
        Panel.gameObject.SetActive(false);
    }
}