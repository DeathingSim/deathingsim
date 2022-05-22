using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    TextMeshProUGUI dialogBox;

    private void Awake()
    {
        dialogBox = FindObjectOfType<TextMeshProUGUI>();
    }

    public void DisplayMessage(string message)
    {
        dialogBox.text = message;
    }
}
