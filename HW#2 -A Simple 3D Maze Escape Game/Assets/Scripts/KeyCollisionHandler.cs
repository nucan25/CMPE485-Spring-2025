using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene reloading

public class KeyCollisionHandler : MonoBehaviour
{
    public GameObject WinPanel; // Win screen panel

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Templa"))
        {   
            // Show the win screen
            WinPanel.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }

    // This method will be linked to the "Play Again" button
    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
