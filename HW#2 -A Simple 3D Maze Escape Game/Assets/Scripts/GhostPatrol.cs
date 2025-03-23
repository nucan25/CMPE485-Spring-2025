using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPatrol : MonoBehaviour
{
    [SerializeField] private Transform pointA; // First patrol point
    [SerializeField] private Transform pointB; // Second patrol point
    [SerializeField] private float speed = 2f; // Movement speed
    [SerializeField] private float detectionRange = 2.5f; // How close the player must be to be detected

    private Transform player;
    private Vector3 target;

    private void Start()
    {
        // Find the player in the scene by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Start moving toward point B
        target = pointB.position;

        // Begin patrol behavior
        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            // Move ghost toward current target point
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // If ghost reaches the target point, switch to the other
            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                target = target == pointA.position ? pointB.position : pointA.position;

                yield return new WaitForSeconds(1f); // Pause briefly before changing direction
            }

            // Check if player is close and in front of the ghost
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            bool isInFront = Vector3.Dot(transform.forward, dirToPlayer) > 0.5f;

            if (distanceToPlayer < detectionRange && isInFront)
            {   
                Debug.Log("Player detected!");
                GameManager.Instance.GameOver(); // Trigger game over when detected
                Debug.Log("Ghost caught the player!");
                yield break; // Stop the coroutine
            }

            yield return null; // Wait for the next frame
        }
    }
}
