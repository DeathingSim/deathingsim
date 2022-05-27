using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{
    Coroutine coroutine;
    public DialogConfiguration dialogConfiguration;
    private string writingText;
    private TextMeshProUGUI writingTextBox;

    public void RunEffect(string text, TextMeshProUGUI textBox, Action callback)
    {
        writingText = text;
        writingTextBox = textBox;

        coroutine = StartCoroutine(TypeText(dialogConfiguration.typeWriterEffectSpeed, callback));
    }

    private IEnumerator TypeText(float speed, Action callback)
    {
        float t = 0;
        int charIndex = 0;

        while(charIndex < writingText.Length)
        {
            t += Time.deltaTime;

            if (t >= speed)
            {
                int c = Mathf.FloorToInt(t / speed);
                charIndex += c;
                t -= speed * c;
            }

            charIndex = Mathf.Clamp(charIndex, 0, writingText.Length);

            writingTextBox.text = writingText.Substring(0, charIndex);

            yield return null;
        }

        writingTextBox.text = writingText;

        callback?.Invoke();
    }

    public void FastEffect(Action callback)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        StartCoroutine(TypeText(dialogConfiguration.typeWriterEffectFastSpeed, callback));
    }
}
