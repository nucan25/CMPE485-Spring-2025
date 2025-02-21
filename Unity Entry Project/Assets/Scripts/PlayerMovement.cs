using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb; // Rigidbody component
    public Transform cameraTransform; // Camera reference
    public float speed = 15f; // Movement speed

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>(); // Automatically assigns Rigidbody if not set
        }

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform; // Automatically finds the main camera
        }
    }

    void FixedUpdate()
    {
        // Get input values
        float moveX = Input.GetAxis("Horizontal"); // A-D or Left-Right arrows
        float moveZ = Input.GetAxis("Vertical");   // W-S or Up-Down arrows

        // Get camera forward and right directions (ignore vertical rotation)
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Normalize to keep movement balanced
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // Calculate movement direction based on camera perspective
        Vector3 movementDirection = (forward * moveZ + right * moveX) * speed;

        // Apply movement force
        rb.AddForce(movementDirection, ForceMode.Force);
    }
}
