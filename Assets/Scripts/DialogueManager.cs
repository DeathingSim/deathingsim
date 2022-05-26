using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameEvent endDialogGameEvent;
    public StringGameEvent showDialogGameEvent;
    public StringArrayGameEvent showQuestionGameEvent;
    
    public TextAsset textAsset;
    private Story story;
    private bool waitingForAnswer;

    private void Start()
    {
        Starte();
    }

    private void Starte()
    {

        story = new Story(textAsset.text);
        ShowNextMessage();
    }

    public void ShowNextMessage()
    {
        if (story.canContinue)
        {
            ShowMessage(story.Continue());
            waitingForAnswer = false;
        }
        else if (story.currentChoices.Count > 0)
        {
            ShowQuestion(story.currentChoices.Select(x => x.text).ToArray());
            waitingForAnswer = true;
        }
        else
            endDialogGameEvent.Raise();
    }

    public void ShowMessage(string message)
    {
        showDialogGameEvent.Raise(message);
    }

    public void ShowQuestion(string[] choices)
    {
        showQuestionGameEvent.Raise(choices);
    }

    public void QuestionAnswered(int choice)
    {
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
