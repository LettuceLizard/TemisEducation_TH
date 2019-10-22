using UnityEngine;
public class HidePanel : MonoBehaviour
{
    public GameObject Panel;
    public void hidePanel()
    {
        Panel.gameObject.SetActive(false);
    }
}