using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    // Called once when the script starts
    void Start()
    {
        Debug.Log("Script is running!"); // Logs a message to the console
    }

    // Called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime); // Moves the object upwards over time
    }
}
