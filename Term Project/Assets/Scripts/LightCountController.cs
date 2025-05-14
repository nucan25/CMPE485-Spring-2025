using UnityEngine;
using UnityEngine.UI;
using TMPro; // If you're using TMP

public class LightCountController : MonoBehaviour
{
    public Light[] testLights;                 // Lights in the scene
    public Slider lightCountSlider;            // UI slider
    public TMP_Text lightCountText;            // UI text (how many lights are active)

    void Start()
    {
        if (lightCountSlider != null)
        {
            lightCountSlider.minValue = 0;
            lightCountSlider.maxValue = testLights.Length; 
            lightCountSlider.wholeNumbers = true;
            lightCountSlider.value = testLights.Length;

            lightCountSlider.onValueChanged.AddListener(delegate {
                int count = (int)lightCountSlider.value;
                ApplyLightCount(count);
            });

            ApplyLightCount((int)lightCountSlider.value);
        }
    }

    public void ApplyLightCount(int count)
    {
        for (int i = 0; i < testLights.Length; i++)
        {
            testLights[i].enabled = (i < count);
        }

        if (lightCountText != null)
        {
            lightCountText.text = count.ToString();
        }
    }
}
