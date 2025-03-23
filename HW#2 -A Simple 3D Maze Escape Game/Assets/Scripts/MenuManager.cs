using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // Aktif sahneyi yeniden başlatabilir veya başka bir sahne yükleyebilirsin
        SceneManager.LoadScene("GameScene"); // veya: SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }




}
