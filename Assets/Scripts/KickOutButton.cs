using UnityEngine;

public class KickOutButton : MonoBehaviour
{
    [SerializeField] private NPCInteraction _nPC;
    [SerializeField] private DialoguePanel _dialoguePanel;

    public void OnButtonClick()
    {
        _nPC.RemoveNPCFromWagon();
        _dialoguePanel.Clouse();
    }
}
