using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform player;      
    [SerializeField] private Transform followPoint; 
    [SerializeField] private float minY = 1.5f; // Kamera'nın asla altına düşmeyeceği minimum yükseklik

    private void LateUpdate()
    {
        Vector3 targetPosition = followPoint.position;

        // Eğer kamera pozisyonu oyuncunun çok altına düşüyorsa, Y eksenini sınırlıyoruz
        if (targetPosition.y < player.position.y + minY)
        {
            targetPosition.y = player.position.y + minY;
        }

        transform.position = targetPosition;
        transform.LookAt(player.position + Vector3.up * 1.5f); // Biraz yukarıdan bakması için
    }
}
