using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class FeelingsUnityEvent : UnityEvent<Feelings> { }

public class FeelingsGameEventListener : GameEventListener<Feelings>
{
    [SerializeField] private FeelingsGameEvent feelingsGameEvent;
    [SerializeField] private FeelingsUnityEvent feelingsUnityEvent;

    public override GameEvent<Feelings> Event => feelingsGameEvent;
    public override UnityEvent<Feelings> Response => feelingsUnityEvent;
}
