using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio
{
    [SerializeField] public AudioClip audio;
}

[CreateAssetMenu(menuName = "Events/Audio Event")]
public class AudioGameEvent : GameEvent<Audio>
{
}