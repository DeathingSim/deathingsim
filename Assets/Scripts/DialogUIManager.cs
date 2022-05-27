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

    public void Awake()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        buttons = panelQuestion.GetComponentsInChildren<Button>().ToList();
    }

    void OnButtonClick(Button button)
    {
        if (choiceGameEvent != null)
            choiceGameEvent.Raise(buttons.IndexOf(button));

        buttons.ForEach(x => x.onClick.RemoveAllListeners());
    }

    public void HideMessage()
    {
        characterName.text = string.Empty;
        dialogBox.text = string.Empty;
    }

    public void ShowQuestion(string[] choices)
    {
        panelQuestion.SetActive(true);
        panelDialog.SetActive(false);

        buttons.ForEach(x => x.gameObject.SetActive(true));

        for (int i = buttons.Count - 1; i >= 0; i--)
        {
            Button button = buttons[i];

            if (i < choices.Length)
            {
                button.gameObject.SetActive(true);
                TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
                text.text = choices[i];
                button.onClick.AddListener(delegate { OnButtonClick(button); });
            }
            else
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    public void ShowDialog(Dialog dialog)
    {
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
        if (Input.GetMouseButtonDown(0) && !writingMessage)
        {
            if (confirmDialogImage != null)
                confirmDialogImage.SetActive(false);
        }
    }
}
