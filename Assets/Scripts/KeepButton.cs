using UnityEngine;

public class KeepButton : MonoBehaviour
{
    [SerializeField] private DialoguePanel _dialoguePanel;

    public void OnButtonClick()
    {
        _dialoguePanel.Clouse();
    }
}
