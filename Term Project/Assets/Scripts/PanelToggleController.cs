using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelToggleController : MonoBehaviour
{
    public GameObject panel;         // Panel to open/close
    public Button toggleButton;      // UI button
    public KeyCode toggleKey = KeyCode.U;

    private bool isVisible = true;

    void Start()
    {
        // Called when the button is clicked
        if (toggleButton != null)
            toggleButton.onClick.AddListener(TogglePanel);
    }

    void Update()
    {
        // Called when the 'U' key is pressed
        if (Input.GetKeyDown(toggleKey))
        {
            TogglePanel();
        }
    }

    public void TogglePanel()
    {
        isVisible = !isVisible;
        panel.SetActive(isVisible);
    }
}
