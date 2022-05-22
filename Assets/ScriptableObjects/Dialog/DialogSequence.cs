using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/Dialog Sequence")]
public class DialogSequence : ScriptableObject
{
    public DialogNode[] dialogs;
}
