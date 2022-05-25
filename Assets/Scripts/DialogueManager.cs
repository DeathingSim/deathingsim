using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public DialogNode currentDialogNode;
    public DialogNodeGameEvent showMessageGameEvent;
    public GameEvent endDialogGameEvent;
    private bool canContinue;

    private void Awake()
    {
    }

    private void Start()
    {
        if (currentDialogNode != null)
        {
            ShowMessage(currentDialogNode);
        }
    }

    private void ShowMessage(DialogNode dialogNode)
    {
        currentDialogNode = dialogNode;
        canContinue = !dialogNode.isQuestion;
        showMessageGameEvent.Raise(dialogNode);
    }

    public void OnChoiceClicked(DialogNode dialogNode)
    {
        ShowMessage(dialogNode);
    }

    void NextMessage()
    {
        // TO DO loop through all nextDialogNodes and evaluate each conditions
        if (currentDialogNode != null && currentDialogNode.nextDialogNodes.Length > 0)
        {
            ShowMessage(currentDialogNode.nextDialogNodes[0]);
        }
        else
        {
            endDialogGameEvent.Raise();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canContinue)
        {
            NextMessage();
        }
    }
}
