using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed; // Rotation sensitivity
    [SerializeField] private float mouseX; // Horizontal mouse movement
    [SerializeField] private float mouseY; // Vertical mouse movement
    [SerializeField] private float minLimit; // Lower pitch limit
    [SerializeField] private float maxLimit; // Upper pitch limit

    private void Update()
    {
        // Get mouse input values
        mouseX = Input.GetAxis("Mouse X"); // Horizontal mouse input
        mouseY = Input.GetAxis("Mouse Y"); // Vertical mouse input

        // Apply horizontal rotation (yaw)
        transform.eulerAngles += new Vector3(0, mouseX * rotationSpeed * Time.deltaTime, 0);

        // Apply vertical rotation (pitch)
        transform.eulerAngles -= new Vector3(mouseY * rotationSpeed * Time.deltaTime, 0, 0);

        float startValue = transform.eulerAngles.x;

        // Clamp vertical rotation to minLimit (looking down)
        if (180 < startValue && startValue < minLimit)
        {
            transform.eulerAngles = new Vector3(minLimit, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        // Clamp vertical rotation to maxLimit (looking up)
        if (maxLimit < startValue && startValue < 180)
        {
            transform.eulerAngles = new Vector3(maxLimit, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
