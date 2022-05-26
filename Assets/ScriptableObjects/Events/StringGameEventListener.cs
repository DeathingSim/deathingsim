using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class StringUnityEvent : UnityEvent<string> { }

public class StringGameEventListener : GameEventListener<string>
{
    [SerializeField] private StringGameEvent stringGameEvent;
    [SerializeField] private StringUnityEvent stringUnityEvent;

    public override GameEvent<string> Event => stringGameEvent;
    public override UnityEvent<string> Response => stringUnityEvent;
}
