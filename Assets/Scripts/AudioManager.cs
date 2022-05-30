using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioSource musicSource;

    public void PlaySound(Audio audio)
    {
        if (soundSource != null)
        {
            soundSource.PlayOneShot(audio.audio);
        }
    }

    public void PlayMusic(Audio audio)
    {
        if (musicSource != null)
        {
            musicSource.clip  = audio.audio;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}