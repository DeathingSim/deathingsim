using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class DialogNodeUnityEvent : UnityEvent<DialogNode> { }

public class DialogNodeGameEventListener : GameEventListener<DialogNode>
{
    [SerializeField] private DialogNodeGameEvent dialogNodeGameEvent;
    [SerializeField] private DialogNodeUnityEvent dialogNodeUnityEvent;

    public override GameEvent<DialogNode> Event => dialogNodeGameEvent;
    public override UnityEvent<DialogNode> Response => dialogNodeUnityEvent;
}
