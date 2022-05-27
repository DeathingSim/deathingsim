using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog
{
    public string characterName;
    public string message;
}

[CreateAssetMenu(menuName = "Events/Dialog Event")]
public class DialogGameEvent : GameEvent<Dialog>
{
}