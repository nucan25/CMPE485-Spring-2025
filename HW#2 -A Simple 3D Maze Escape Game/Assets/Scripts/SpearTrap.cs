using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrap : MonoBehaviour
{
    [SerializeField] private Transform spear;           // The spear object that will move
    [SerializeField] private float moveDistance = 2f;   // How far the spear moves up
    [SerializeField] private float moveSpeed = 2f;      // Movement speed
    [SerializeField] private float waitTime = 1f;       // Wait time before switching direction

    private Vector3 downPosition; // Spear's initial (down) position
    private Vector3 upPosition;   // Spear's raised position
    private bool movingUp = true; // Direction flag

    private void Start()
    {
        // Set up and down positions based on initial local position
        downPosition = spear.localPosition;
        upPosition = downPosition + Vector3.up * moveDistance;

        // Start moving the spear up and down repeatedly
        StartCoroutine(SpearCycle());
    }

    private IEnumerator SpearCycle()
    {
        while (true)
        {
            Vector3 target = movingUp ? upPosition : downPosition;

            // Smoothly move toward the target position
            while (Vector3.Distance(spear.localPosition, target) > 0.01f)
            {
                spear.localPosition = Vector3.MoveTowards(spear.localPosition, target, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // Switch direction
            movingUp = !movingUp;

            // Wait before next move
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if spear is in danger position and collided with player
        if (movingUp && other.CompareTag("Player"))
        {
            GameManager.Instance.GameOver(); // Trigger game over
            Debug.Log("Player killed by spear trap!");
        }
    }
}
