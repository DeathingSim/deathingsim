using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class IntArrayUnityEvent : UnityEvent<int[]> { }

public class IntArrayGameEventListener : GameEventListener<int[]>
{
    [SerializeField] private IntArrayGameEvent intArrayGameEvent;
    [SerializeField] private IntArrayUnityEvent intArrayUnityEvent;

    public override GameEvent<int[]> Event => intArrayGameEvent;
    public override UnityEvent<int[]> Response => intArrayUnityEvent;
}
