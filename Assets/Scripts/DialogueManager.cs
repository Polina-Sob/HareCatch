using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private GameObject _choiceButtonPrefab;
    [SerializeField] private Transform _choiceContainer;
    [SerializeField] private TextMeshProUGUI _dialogueText;

    private DialogueData _currentDialogue;
    private NPCInteraction _NPC;

    private void Awake()
    {
        _dialoguePanel.SetActive(false);
    }

    public void StartDialogue(DialogueData dialogueData, NPCInteraction nPCInteraction)
    {
        _NPC = nPCInteraction;
        _currentDialogue = dialogueData;
        _dialoguePanel.SetActive(true);
        DisplayDialogue(dialogueData);
    }

    private void DisplayDialogue(DialogueData data)
    {

    }

}
