using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{
    public DialogConfiguration dialogConfiguration;
    public bool IsRunning { get; private set; }

    public void RunEffect(string text, TextMeshProUGUI textBox, Action callback)
    {
        IsRunning = true;
        StartCoroutine(TypeText(text, textBox, callback));
    }

    private IEnumerator TypeText(string text, TextMeshProUGUI textBox, Action callback)
    {
        float t = 0;
        int charIndex = 0;

        while(charIndex < text.Length && IsRunning)
        {
            t += Time.deltaTime;
            charIndex = Mathf.FloorToInt(t / dialogConfiguration.typeWriterEffectSpeed);
            charIndex = Mathf.Clamp(charIndex, 0, text.Length);

            textBox.text = text.Substring(0, charIndex);

            yield return null;
        }

        textBox.text = text;

        callback?.Invoke();
    }

    public void SkipEffect(string text, TextMeshProUGUI textBox)
    {
        IsRunning = false;
    }
}
