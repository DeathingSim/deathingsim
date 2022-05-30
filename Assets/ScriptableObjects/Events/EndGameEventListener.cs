using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class EndUnityEvent : UnityEvent<Ending> { }

public class EndGameEventListener : GameEventListener<Ending>
{
    [SerializeField] private EndGameEvent endGameEvent;
    [SerializeField] private EndUnityEvent endUnityEvent;

    public override GameEvent<Ending> Event => endGameEvent;
    public override UnityEvent<Ending> Response => endUnityEvent;
}
