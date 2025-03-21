using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Diğer scriptlerden kolayca erişim için
    [SerializeField] private AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Sahneler arası yok olmasın
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
            musicSource.Play(); // Oyun başladığında müzik başlasın
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume; // 0 ile 1 arasında ses ayarlanır
    }

    public void ToggleMute()
    {
        musicSource.mute = !musicSource.mute;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMute(); // "M" tuşuna basarak sessize al / geri aç
        }
    }
}
