using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogUIManager : MonoBehaviour
{
    public TextMeshProUGUI dialogBox;
    public GameObject panelDialog;
    public GameObject panelQuestion;
    public TextMeshProUGUI characterName;
    public IntGameEvent choiceGameEvent;
    public GameObject buttonPrefab;
    private List<Button> buttons;
    public float buttonOffset;
    private TypeWriterEffect typeWriterEffect;
    public GameObject confirmDialogImage;
    private bool writingMessage;
    private bool isQuestion;

    public void Awake()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        buttons = panelQuestion.GetComponentsInChildren<Button>().ToList();
    }

    void OnButtonClick(Button button, int nbChoices)
    {
        if (choiceGameEvent != null)
            choiceGameEvent.Raise(buttons.IndexOf(button) - (buttons.Count - nbChoices));

        buttons.ForEach(x => x.onClick.RemoveAllListeners());
    }

    public void HideMessage()
    {
        panelQuestion.SetActive(false);
        panelDialog.SetActive(false);
        characterName.text = string.Empty;
        dialogBox.text = string.Empty;
    }

    public void ShowQuestion(string[] choices)
    {
        isQuestion = true;

        panelQuestion.SetActive(true);
        panelDialog.SetActive(false);

        buttons.ForEach(x => x.gameObject.SetActive(false));

        int startingIndex = buttons.Count - choices.Length;

        for (int i = startingIndex; i < buttons.Count; i++)
        {
            Button button = buttons[i];

            button.gameObject.SetActive(true);
            TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
            text.text = choices[i - startingIndex];
            button.onClick.AddListener(delegate { OnButtonClick(button, choices.Length); });
        }
    }

    public void ShowDialog(Dialog dialog)
    {
        isQuestion = false;
        writingMessage = true;

        panelQuestion.SetActive(false);
        panelDialog.SetActive(true);

        characterName.text = dialog.characterName;

        if (typeWriterEffect != null)
        {
            typeWriterEffect.RunEffect(dialog.message, dialogBox, MessageShown);
        }
        else
        {
            dialogBox.text = dialog.message;
            MessageShown();
        }
    }

    public void MessageShown()
    {
        writingMessage = false;
        if (confirmDialogImage != null)
            confirmDialogImage.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isQuestion)
        {
            if (!writingMessage)
            {
                choiceGameEvent.Raise(-1);
                if (confirmDialogImage != null)
                    confirmDialogImage.SetActive(false);
            }
            else
            {
                typeWriterEffect?.FastEffect(MessageShown);
            }
        }
    }
}