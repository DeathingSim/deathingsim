using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/Dialog Node")]
public class DialogNode : ScriptableObject
{
    public GameEvent onDisplay;
    public Character character;
    public string previewText;
    public string text;
    public bool isQuestion;

    public Condition[] conditions;

    public DialogNode[] nextDialogNodes;
}
