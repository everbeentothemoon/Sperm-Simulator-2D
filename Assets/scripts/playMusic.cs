using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : MonoBehaviour
{
    public AudioSource musicSource; // Reference to the AudioSource component
    public AudioClip musicClip; // The music clip to play

    private void Start()
    {
        // Assign the music clip to the AudioSource
        musicSource.clip = musicClip;

        // Play the music
        musicSource.Play();
    }
}
