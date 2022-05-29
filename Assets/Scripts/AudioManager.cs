using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(Audio audio)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audio.audio);
        }
    }
}
