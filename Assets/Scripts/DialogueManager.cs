using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameEvent endDialogGameEvent;
    public DialogGameEvent showDialogGameEvent;
    public StringArrayGameEvent showQuestionGameEvent;
    public BooleanGameEvent showFeelingsBarGameEvent;
    public AudioGameEvent playSoundGameEvent;
    public AudioClip[] sounds;
    public GameState gameState;
    
    public TextAsset textAsset;
    private Story story;
    private bool waitingForAnswer;

    private void Start()
    {
        story = new Story(textAsset.text);
        List<string> hps = new List<string>() { "HP1", "HP2", "HP3", "HP4", "HP5" };
        story.ObserveVariables(hps.ToList(), (variableName, newValue) =>
        {
            switch (variableName)
            {
                case "HP1": gameState.SetFeelings(0, (int)newValue); break;
                case "HP2": gameState.SetFeelings(1, (int)newValue); break;
                case "HP3": gameState.SetFeelings(2, (int)newValue); break;
                case "HP4": gameState.SetFeelings(3, (int)newValue); break;
                case "HP5": gameState.SetFeelings(4, (int)newValue); break;
            }
        });

        story.BindExternalFunction<bool>(nameof(ShowFeelingsBar), ShowFeelingsBar);
        story.BindExternalFunction<string>(nameof(PlaySound), PlaySound);

        ShowNextMessage();
    }

    private void ShowFeelingsBar(bool displayed)
    {
        showFeelingsBarGameEvent?.Raise(displayed);
    }

    private void PlaySound(string sound)
    {
        AudioClip clip = sounds.FirstOrDefault(x => x.name == sound);
        if (clip != null)
            playSoundGameEvent?.Raise(new Audio() { audio = clip });
    }

    public void ShowNextMessage()
    {
        if (story.canContinue)
        {
            string message = story.Continue();
            string characterName = string.Empty;
            Regex regex = new Regex(@"(^\S+):(.+)");
            Match match = regex.Match(message);

            if (match.Success)
            {
                characterName = match.Groups[1].Value;
                message = match.Groups[2].Value;
            }

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