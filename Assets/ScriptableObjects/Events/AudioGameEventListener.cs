using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class AudioUnityEvent : UnityEvent<Audio> { }

public class AudioGameEventListener : GameEventListener<Audio>
{
    [SerializeField] private AudioGameEvent audioGameEvent;
    [SerializeField] private AudioUnityEvent audioUnityEvent;

    public override GameEvent<Audio> Event => audioGameEvent;
    public override UnityEvent<Audio> Response => audioUnityEvent;
}
