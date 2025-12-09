using UnityEngine;

public class DialoguePanel : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Clouse()
    {
        gameObject.SetActive(false);
    }
}
