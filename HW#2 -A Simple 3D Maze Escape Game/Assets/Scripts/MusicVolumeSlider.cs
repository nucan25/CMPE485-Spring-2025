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

        // Varsayılan değeri 1 (maksimum ses)
        slider.value = 1f;

        // Değer değişince AudioManager'a bildir
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