using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feelings
{
    public int[] FeelingsValues;
    public int[] MaxFeelingsValues;
}

[CreateAssetMenu(menuName = "Events/Feelings Event")]
public class FeelingsGameEvent : GameEvent<Feelings>
{
}