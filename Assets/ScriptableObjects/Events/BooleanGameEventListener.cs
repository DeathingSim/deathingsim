using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class BooleanUnityEvent : UnityEvent<bool> { }

public class BooleanGameEventListener : GameEventListener<bool>
{
    [SerializeField] private BooleanGameEvent booleanGameEvent;
    [SerializeField] private BooleanUnityEvent booleanUnityEvent;

    public override GameEvent<bool> Event => booleanGameEvent;
    public override UnityEvent<bool> Response => booleanUnityEvent;
}
