using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForceScript : MonoBehaviour
{
    public Rigidbody rb; // Assign this via Inspector
    public Vector3 forceDirection = new Vector3(1, 0, 0); // Default force direction (X-axis)
    public float forceAmount = 10f; // Strength of the applied force

    void Start()
    {
        if (rb == null)
        {
            Debug.LogError("Rigidbody is not assigned! Please assign it in the Inspector.");
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.AddForce(forceDirection.normalized * forceAmount, ForceMode.Force);
        }
    }
}

