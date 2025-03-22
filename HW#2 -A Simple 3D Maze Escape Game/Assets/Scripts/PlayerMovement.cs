using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; // Movement speed of the player
    [SerializeField] private Vector3 movementVector; // Raw input movement vector

    [SerializeField] private float horizontal; // Horizontal input (left-right)
    [SerializeField] private float vertical;   // Vertical input (forward-back)

    private Rigidbody rb; // Reference to the player's Rigidbody
    private AnimatorPlayer animatorPlayer; // Custom animation controller script

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animatorPlayer = GetComponent<AnimatorPlayer>();
    }

    private void Update()
    {
        // Get input values from keyboard (WASD or arrow keys)
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // Create a movement vector from input
        movementVector = new Vector3(horizontal, 0, vertical);
        movementVector.Normalize(); // Normalize to prevent faster diagonal movement

        // Convert local movement direction to world space
        Vector3 tempMovementVector = Vector3.zero;
        tempMovementVector += transform.forward * movementVector.z;
        tempMovementVector += transform.right * movementVector.x;

        // Move the player using Rigidbody
        rb.MovePosition(transform.position + tempMovementVector * speed * Time.deltaTime);

        // Handle animation state based on movement
        if (movementVector != Vector3.zero) // If the player is moving
        {
            animatorPlayer.SetBool("Run", true);
        }
        else // If the player is idle
        {
            animatorPlayer.SetBool("Run", false);
        }
    }
}
