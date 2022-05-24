using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Feelings : MonoBehaviour
{

    [SerializeField] private int[] minFeelings = new int[5] {0, 0, 0, 0, 0};
    [SerializeField] private int[] maxFeelings = new int[5] {80, 80, 80, 80, 80};
    [SerializeField] private GameObject heartBarParent = null;
    [SerializeField] private Image[] heartBarImage = null;

    private int[] currentFeelings;

    // Start is called before the first frame update
    void Start()
    {
        currentFeelings = minFeelings;
    }

    public void AddLove(int Scene, int LoveAmount)
    {
        if(currentFeelings[Scene] == maxFeelings[Scene]) { return; }
        currentFeelings[Scene] = Mathf.Max(currentFeelings[Scene] + LoveAmount, maxFeelings[Scene]);
        UpdateFeelings(currentFeelings);
    }

    public void Add15Love1()
    {
        int Scene = 0;
        if(currentFeelings[Scene] == maxFeelings[Scene]) { return; }
        currentFeelings[Scene] = Mathf.Min(currentFeelings[Scene] + 15, maxFeelings[Scene]);
        Debug.Log(currentFeelings[0] + ";" + currentFeelings[1] + ";" + currentFeelings[2] + ";" + currentFeelings[3] + ";" + currentFeelings[4]);
        UpdateFeelings(currentFeelings);
    }

    public void Add15Love2()
    {
        int Scene = 1;
        if(currentFeelings[Scene] == maxFeelings[Scene]) { return; }
        currentFeelings[Scene] = Mathf.Min(currentFeelings[Scene] + 15, maxFeelings[Scene]);
        Debug.Log(currentFeelings[0] + ";" + currentFeelings[1] + ";" + currentFeelings[2] + ";" + currentFeelings[3] + ";" + currentFeelings[4]);
        UpdateFeelings(currentFeelings);
    }

    public void Add15Love3()
    {
        int Scene = 2;
        if(currentFeelings[Scene] == maxFeelings[Scene]) { return; }
        currentFeelings[Scene] = Mathf.Min(currentFeelings[Scene] + 15, maxFeelings[Scene]);
        Debug.Log(currentFeelings[0] + ";" + currentFeelings[1] + ";" + currentFeelings[2] + ";" + currentFeelings[3] + ";" + currentFeelings[4]);
        UpdateFeelings(currentFeelings);
    }

    public void Add15Love4()
    {
        int Scene = 3;
        if(currentFeelings[Scene] == maxFeelings[Scene]) { return; }
        currentFeelings[Scene] = Mathf.Min(currentFeelings[Scene] + 15, maxFeelings[Scene]);
        Debug.Log(currentFeelings[0] + ";" + currentFeelings[1] + ";" + currentFeelings[2] + ";" + currentFeelings[3] + ";" + currentFeelings[4]);
        UpdateFeelings(currentFeelings);
    }

    public void Add15Love5()
    {
        int Scene = 4;
        if(currentFeelings[Scene] == maxFeelings[Scene]) { return; }
        currentFeelings[Scene] = Mathf.Min(currentFeelings[Scene] + 15, maxFeelings[Scene]);
        Debug.Log(currentFeelings[0] + ";" + currentFeelings[1] + ";" + currentFeelings[2] + ";" + currentFeelings[3] + ";" + currentFeelings[4]);
        UpdateFeelings(currentFeelings);
    }

    private void UpdateFeelings(int[] currentFeelings)
    {
        for(int i = 0; i < 5; i++)
        {
            heartBarImage[i].fillAmount = (float)currentFeelings[i] / maxFeelings[i];
        }
    }
}
