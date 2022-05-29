using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "States/Game State")]
public class GameState : ScriptableObject
{
    public FeelingsGameEvent feelingsGameEvent;

    public int[] MinFeelings;
    public int[] MaxFeelings;

    public int[] Feelings { get; private set; }

    private void OnEnable()
    {
        Feelings = new int[MinFeelings.Length];
        MinFeelings.CopyTo(Feelings, 0);
    }

    public void SetFeelings(int index, int amount)
    {
        if (index >= Feelings.Length || index >= MinFeelings.Length || index >= MaxFeelings.Length)
            return;

        int newAmount = Mathf.Clamp(amount, MinFeelings[index], MaxFeelings[index]);

        if (Feelings[index] != newAmount)
        {
            Feelings[index] = amount;
            feelingsGameEvent?.Raise(new Feelings() { FeelingsValues = Feelings, MaxFeelingsValues = MaxFeelings });
        } 
    }
}
