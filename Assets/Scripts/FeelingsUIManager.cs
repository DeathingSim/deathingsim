using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FeelingsUIManager : MonoBehaviour
{
    [SerializeField] private GameObject heartBarParent = null;
    [SerializeField] private Image[] heartBarImage = null;

    public void UpdateFeelings(Feelings feelings)
    {
        for(int i = 0; i < 5; i++)
        {
            heartBarImage[i].fillAmount = (float)feelings.FeelingsValues[i] / feelings.MaxFeelingsValues[i];
        }
    }

    public void ShowFeelingsBar(bool displayed)
    {
        heartBarParent.SetActive(displayed);
    }
}