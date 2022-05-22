using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/Choice Condition")]
public class ChoiceCondition : Condition
{
    public DialogNode[] choices;
}
