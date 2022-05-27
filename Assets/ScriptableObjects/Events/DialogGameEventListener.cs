using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class DialogUnityEvent : UnityEvent<Dialog> { }

public class DialogGameEventListener : GameEventListener<Dialog>
{
    [SerializeField] private DialogGameEvent dialogGameEvent;
    [SerializeField] private DialogUnityEvent dialogUnityEvent;

    public override GameEvent<Dialog> Event => dialogGameEvent;
    public override UnityEvent<Dialog> Response => dialogUnityEvent;
}
