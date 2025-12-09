using UnityEngine;
using TMPro;

public class TextBarManager : MonoBehaviour
{
    [SerializeField] private NPCInteraction _nPC;

    [Header("UI Элементы")]
    [Tooltip("Основное, большое поле для текста диалога.")]
    [SerializeField] private TextMeshProUGUI _mainTextDisplay;
    [Tooltip("Мини-поле, которое должно синхронизироваться.")]
    [SerializeField] private TextMeshProUGUI _miniTextDisplay;

    [Header("Настройки Диалога")]
    [Tooltip("Массив строк, которые будут последовательно отображаться.")]
    [SerializeField] private string[] _dialogueLines;

    [Header("Настройки Имени Говорящего")]
    [Tooltip("Два варианта имени, между которыми будет переключаться мини-текст.")]
    [SerializeField] private string speakerNameOption1 = "Контролер";
    [SerializeField] private string speakerNameOption2;

    [Header("Кнопки")]
    [SerializeField] private KeepButton _keepButton;
    [SerializeField] private KickOutButton _kickOutButton;

    private int _currentLineIndex = 0;
    private int _currentSpeakerIndex = 0;
    private bool _isDialogueActive = false;
    private bool _isDialogueEnd = false;

    private void OnEnable()
    {
        StartDialogueSequence(_dialogueLines);
    }

    private void Update()
    {
        if (_isDialogueActive)
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isDialogueEnd == false)
            {
                AdvanceDialogue();
            }
        }
    }

    private void StartDialogueSequence(string[] lines)
    {
        _dialogueLines = lines;
        _currentLineIndex = 0;
        SetDialogueActive(true);
        DisplayCurrentLine();
    }

    private void AdvanceDialogue()
    {
        ToggleSpeakerName();

        if (_currentLineIndex < _dialogueLines.Length - 1)
        {
            _currentLineIndex++;
            DisplayCurrentLine();
        }
        else
        {
            EndDialogueSequence();
        }
    }

    private void ToggleSpeakerName()
    {
        _currentSpeakerIndex = 1 - _currentSpeakerIndex;

        if (_miniTextDisplay != null)
        {
            _miniTextDisplay.text = (_currentSpeakerIndex == 0) ? speakerNameOption1 : speakerNameOption2;
        }
    }

    private void DisplayCurrentLine()
    {
        if (_dialogueLines.Length > 0 && _currentLineIndex < _dialogueLines.Length)
        {
            string line = _dialogueLines[_currentLineIndex];

            _mainTextDisplay.text = line;

            if (_miniTextDisplay != null && _currentLineIndex == 0)
            {
                _miniTextDisplay.text = (_currentSpeakerIndex == 0) ? speakerNameOption1 : speakerNameOption2;
            }
        }
    }

    private void EndDialogueSequence()
    {
        _isDialogueEnd = true;
        _currentLineIndex = 0;
        _dialogueLines = null;

        CleanText();
        ActivateChoice();
    }

    private void SetDialogueActive(bool isActive)
    {
        _isDialogueActive = isActive;

        if (_mainTextDisplay != null && _mainTextDisplay.transform.parent != null)
        {
            _mainTextDisplay.transform.parent.gameObject.SetActive(isActive);
        }
        else if (_mainTextDisplay != null)
        {
            _mainTextDisplay.gameObject.SetActive(isActive);
        }
    }

    private void ActivateChoice()
    {
        _keepButton.gameObject.SetActive(true);
        _kickOutButton.gameObject.SetActive(true);
        _nPC.GetComponent<Collider2D>().enabled = false;
    }

    private void CleanText()
    {
        if (_mainTextDisplay != null)
        {
            _mainTextDisplay.text = "";
        }

        if (_miniTextDisplay != null)
        {
            _miniTextDisplay.text = "";
        }
    }
}