using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/Choice Node")]
public class ChoiceNode : ScriptableObject
{
    public DialogNode[] choices;
}
