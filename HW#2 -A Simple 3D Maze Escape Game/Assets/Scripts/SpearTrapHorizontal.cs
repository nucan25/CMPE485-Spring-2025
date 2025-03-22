using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrapHorizontal : MonoBehaviour
{
    [SerializeField] private Transform spear;           // The object to move (spear model)
    [SerializeField] private float moveDistance = 2f;   // Distance to move right and left
    [SerializeField] private float moveSpeed = 2f;      // Movement speed
    [SerializeField] private float waitTime = 1f;       // Pause time between movements

    private Vector3 leftPosition;   // Start (left) position
    private Vector3 rightPosition;  // Target (right) position
    private bool movingRight = true;

    private void Start()
    {
        // Calculate left and right positions based on local position
        leftPosition = spear.localPosition;
        rightPosition = leftPosition + Vector3.right * moveDistance;

        // Start the movement cycle
        StartCoroutine(MoveSpear());
    }

    private IEnumerator MoveSpear()
    {
        while (true)
        {
            Vector3 target = movingRight ? rightPosition : leftPosition;

            // Move toward the target position smoothly
            while (Vector3.Distance(spear.localPosition, target) > 0.01f)
            {
                spear.localPosition = Vector3.MoveTowards(spear.localPosition, target, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // Switch direction
            movingRight = !movingRight;

            // Wait before changing direction
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Trigger game over if the player touches the spear
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
            Debug.Log("Player was hit by horizontal spear!");
        }
    }
}
