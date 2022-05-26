using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class StringArrayUnityEvent : UnityEvent<string[]> { }

public class StringArrayGameEventListener : GameEventListener<string[]>
{
    [SerializeField] private StringArrayGameEvent stringArrayGameEvent;
    [SerializeField] private StringArrayUnityEvent stringArrayUnityEvent;

    public override GameEvent<string[]> Event => stringArrayGameEvent;
    public override UnityEvent<string[]> Response => stringArrayUnityEvent;
}
