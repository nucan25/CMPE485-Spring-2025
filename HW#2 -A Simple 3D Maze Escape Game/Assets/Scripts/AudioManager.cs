using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; 
    [SerializeField] private AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent from being destroyed between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play(); // Start music when the game begins
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume; // Set volume between 0 and 1
    }

    public void ToggleMute()
    {
        musicSource.mute = !musicSource.mute;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMute(); // Press "M" to mute/unmute the music
        }
    }
}
