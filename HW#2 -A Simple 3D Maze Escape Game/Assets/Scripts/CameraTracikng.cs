using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform player;        // Reference to the player
    [SerializeField] private Transform followPoint;   // Camera's follow target point
    [SerializeField] private float minY = 1.5f;       // Minimum Y offset to prevent the camera from dropping too low

    private void LateUpdate()
    {
        Vector3 targetPosition = followPoint.position;

        // If the camera's position is too low compared to the player, clamp the Y value
        if (targetPosition.y < player.position.y + minY)
        {
            targetPosition.y = player.position.y + minY;
        }

        transform.position = targetPosition;

        // Make the camera look slightly above the player's position
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}
