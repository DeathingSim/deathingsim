using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class IntUnityEvent : UnityEvent<int> { }

public class IntGameEventListener : GameEventListener<int>
{
    [SerializeField] private IntGameEvent intGameEvent;
    [SerializeField] private IntUnityEvent intUnityEvent;

    public override GameEvent<int> Event => intGameEvent;
    public override UnityEvent<int> Response => intUnityEvent;
}
