using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUIManager : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI endText;
    public Image bgImage;
    public GameEvent playAgainGameEvent;

    public void PlayAgain()
    {
        panel.SetActive(false);
        playAgainGameEvent?.Raise();
    }

    public void DisplayEndGame(Ending ending)
    {
        bgImage.color = ending.color;
        endText.text = ending.endingText;
        panel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}