using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LightTestUIController : MonoBehaviour
{
    [Header("Lights")]
    public Light directionalLight;
    public Light[] testLights;

    [Header("UI Controls")]
    public Toggle directionalToggle;
    public TMP_Dropdown lightTypeDropdown;
    public TMP_Dropdown shadowDropdown;
    public Slider intensitySlider;
    public Slider rotationSlider;

    [Header("UI Value Displays")]
    public TMP_Text intensityValueText;
    public TMP_Text rotationValueText;

    [Header("Advanced Controls")]
    public TMP_Dropdown shadowResolutionDropdown;
    public TMP_Dropdown lightModeDropdown;

    [Header("RGB Sliders")]
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    [Header("RGB Value Texts")]
    public TMP_Text redValueText;
    public TMP_Text greenValueText;
    public TMP_Text blueValueText;

    void Start()
    {
        // Enable/disable directional light based on toggle at start
        if (directionalToggle != null && directionalLight != null)
            directionalLight.enabled = directionalToggle.isOn;

        // Show initial slider values
        UpdateIntensityValue(intensitySlider?.value ?? 0);
        UpdateRotationValue(rotationSlider?.value ?? 0);
        UpdateLightColor();

        // Attach listeners
        if (directionalToggle != null)
            directionalToggle.onValueChanged.AddListener(OnToggleDirectionalLight);

        if (lightTypeDropdown != null)
            lightTypeDropdown.onValueChanged.AddListener(OnChangeLightType);

        if (intensitySlider != null)
            intensitySlider.onValueChanged.AddListener(OnIntensityChanged);

        if (shadowDropdown != null)
            shadowDropdown.onValueChanged.AddListener(OnShadowTypeChanged);

        if (rotationSlider != null)
            rotationSlider.onValueChanged.AddListener(OnRotationChanged);

        if (shadowResolutionDropdown != null)
            shadowResolutionDropdown.onValueChanged.AddListener(OnShadowResolutionChanged);

        if (lightModeDropdown != null)
            lightModeDropdown.onValueChanged.AddListener(OnLightModeChanged);

        if (redSlider != null)
            redSlider.onValueChanged.AddListener(_ => UpdateLightColor());
        if (greenSlider != null)
            greenSlider.onValueChanged.AddListener(_ => UpdateLightColor());
        if (blueSlider != null)
            blueSlider.onValueChanged.AddListener(_ => UpdateLightColor());
    }

    void OnToggleDirectionalLight(bool isOn)
    {
        if (directionalLight != null)
            directionalLight.enabled = isOn;
    }

    void OnChangeLightType(int index)
    {
        LightType type = (index == 0) ? LightType.Point : LightType.Spot;
        foreach (var light in testLights)
        {
            if (light != null)
                light.type = type;
        }
    }

    void OnIntensityChanged(float value)
    {
        foreach (var light in testLights)
        {
            if (light != null)
                light.intensity = value;
        }

        UpdateIntensityValue(value);
    }

    void OnShadowTypeChanged(int index)
    {
        LightShadows shadow = LightShadows.None;
        if (index == 1) shadow = LightShadows.Hard;
        if (index == 2) shadow = LightShadows.Soft;

        foreach (var light in testLights)
        {
            if (light != null)
                light.shadows = shadow;
        }
    }

    void OnRotationChanged(float value)
    {
        if (directionalLight != null && directionalLight.enabled)
            directionalLight.transform.rotation = Quaternion.Euler(value, 30, 0);

        UpdateRotationValue(value);
    }

    void OnShadowResolutionChanged(int index)
    {
        switch (index)
        {
            case 0: QualitySettings.shadowResolution = ShadowResolution.Low; break;
            case 1: QualitySettings.shadowResolution = ShadowResolution.Medium; break;
            case 2: QualitySettings.shadowResolution = ShadowResolution.High; break;
            case 3: QualitySettings.shadowResolution = ShadowResolution.VeryHigh; break;
        }
    }

    void OnLightModeChanged(int index)
    {
        LightmapBakeType mode = LightmapBakeType.Realtime;
        if (index == 1) mode = LightmapBakeType.Mixed;
        else if (index == 2) mode = LightmapBakeType.Baked;

        foreach (var light in testLights)
        {
            if (light != null)
                light.lightmapBakeType = mode;
        }
    }

    void UpdateLightColor()
    {
        float r = redSlider?.value ?? 1f;
        float g = greenSlider?.value ?? 1f;
        float b = blueSlider?.value ?? 1f;

        foreach (var light in testLights)
        {
            if (light != null)
                light.color = new Color(r, g, b);
        }

        if (redValueText != null) redValueText.text = r.ToString("F2");
        if (greenValueText != null) greenValueText.text = g.ToString("F2");
        if (blueValueText != null) blueValueText.text = b.ToString("F2");
    }

    void UpdateIntensityValue(float value)
    {
        if (intensityValueText != null)
            intensityValueText.text = value.ToString("F1");
    }

    void UpdateRotationValue(float value)
    {
        if (rotationValueText != null)
            rotationValueText.text = value.ToString("F0") + "°";
    }
}
