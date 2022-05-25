using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogUIManager : MonoBehaviour
{
    public TextMeshProUGUI dialogBox;
    public GameObject panelDialog;
    public GameObject panelQuestion;
    public Button[] buttons;
    public TextMeshProUGUI characterName;
    public DialogNodeGameEvent gameEvent;

    public void Awake()
    {
    }

    void OnButtonClick(DialogNode choiceSelected)
    {
        if (gameEvent != null)
            gameEvent.Raise(choiceSelected);
    }

    public void HideMessage()
    {
        characterName.text = string.Empty;
        dialogBox.text = string.Empty;
    }

    public void ShowMessage(DialogNode dialogNode)
    {
        if (dialogNode.isQuestion)
        {
            panelQuestion.SetActive(true);
            panelDialog.SetActive(false);
            for (int i = 0; i < dialogNode.nextDialogNodes.Length; i++)
            {
                DialogNode nextDialogNode = dialogNode.nextDialogNodes[i];
                TextMeshProUGUI text = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
                text.text = nextDialogNode.previewText;
                buttons[i].onClick.AddListener(delegate { OnButtonClick(nextDialogNode); });
            }
        }
        else
        {
            panelQuestion.SetActive(false);
            panelDialog.SetActive(true);
            characterName.text = dialogNode.character?.characterName ?? string.Empty;
            dialogBox.text = dialogNode.text;
        }
    }
}
