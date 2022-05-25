using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/Dialog History")]
public class DialogHistory : ScriptableObject
{
    public List<DialogNode> visitedDialogNodes;
}
