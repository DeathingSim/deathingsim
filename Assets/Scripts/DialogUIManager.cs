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

    public void Awake()
    {
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

        RectTransform r = panelQuestion.GetComponent<RectTransform>();
        RectTransform br = buttonPrefab.GetComponent<RectTransform>();

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

    public void ShowMessage(string message)
    {
        panelQuestion.SetActive(false);
        panelDialog.SetActive(true);
        dialogBox.text = message;
    }
}
