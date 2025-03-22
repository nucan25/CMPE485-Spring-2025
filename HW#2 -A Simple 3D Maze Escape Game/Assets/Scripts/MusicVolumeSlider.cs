using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();

        // Set default slider value to 1 (maximum volume)
        slider.value = 1f;

        // Add a listener to notify the AudioManager when the value changes
        slider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetMusicVolume(value);
        }
    }
}
