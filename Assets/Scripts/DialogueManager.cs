using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    const string CharacterNameVariable = "CNAME";

    public GameEvent endDialogGameEvent;
    public DialogGameEvent showDialogGameEvent;
    public StringArrayGameEvent showQuestionGameEvent;
    
    public TextAsset textAsset;
    private Story story;
    private bool waitingForAnswer;

    private void Start()
    {
        story = new Story(textAsset.text);
        ShowNextMessage();
    }

    public void ShowNextMessage()
    {
        if (story.canContinue)
        {
            string message = story.Continue();
            string characterName = story.variablesState.GlobalVariableExistsWithName(CharacterNameVariable) ? (string)story.variablesState[CharacterNameVariable] : string.Empty;

            Dialog dialog = new Dialog()
            {
                message = message,
                characterName = characterName
            };
            ShowMessage(dialog);
            waitingForAnswer = true;
        }
        else if (story.currentChoices.Count > 0)
        {
            ShowQuestion(story.currentChoices.Select(x => x.text).ToArray());
            waitingForAnswer = true;
        }
        else
            endDialogGameEvent.Raise();
    }

    public void ShowMessage(Dialog dialog)
    {
        showDialogGameEvent.Raise(dialog);
    }

    public void ShowQuestion(string[] choices)
    {
        showQuestionGameEvent.Raise(choices);
    }

    public void QuestionAnswered(int choice)
    {
        if (choice >= 0)
            story.ChooseChoiceIndex(choice);

        ShowNextMessage();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !waitingForAnswer)
        {
            ShowNextMessage();
        }
    }
}