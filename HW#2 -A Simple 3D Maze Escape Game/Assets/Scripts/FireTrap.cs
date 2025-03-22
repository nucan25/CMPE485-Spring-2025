using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FireTrap : MonoBehaviour
{
    [SerializeField] private float interval = 2f; // On-off delay
    [SerializeField] private List<GameObject> fireEffects; // All fire effects under this trap

    private bool isActive = false;

    private void Start()
    {
        StartCoroutine(FireCycle());
    }

    private IEnumerator FireCycle()
    {
        while (true)
        {
            isActive = !isActive;

            foreach (GameObject fx in fireEffects)
            {
                fx.SetActive(isActive);
            }

            yield return new WaitForSeconds(interval);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive && other.CompareTag("Player"))
        {
           

            GameManager.Instance.GameOver();

            Debug.Log("Player burned by multiple fire traps!");
            // Add Game Over logic here (panel, restart, etc.)
        }
    }
}

