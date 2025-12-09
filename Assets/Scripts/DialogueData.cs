using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Scriptable Dialogue/DialogueData")]
public class DialogueData : ScriptableObject
{
    [SerializeField] private string _dialogueText;
    [SerializeField] private List<Choice> _choices;

    [Serializable]
    public class Choice
    {
        [SerializeField] private DialogueData _nextDialogue;
        [SerializeField] private string _choiceText;
        [SerializeField] private bool _endsConversation = false;

        public DialogueData Dialogue => _nextDialogue;
        public string ChoiceText => _choiceText;
        public bool EndsConversation => _endsConversation;
    }

}
