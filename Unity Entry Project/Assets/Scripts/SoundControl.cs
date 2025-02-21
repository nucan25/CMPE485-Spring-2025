using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) // When the "M" key is pressed
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause(); // Pause the currently playing sound
            }
            else
            {
                audioSource.Play(); // Resume the paused sound
            }
        }
    }
}

