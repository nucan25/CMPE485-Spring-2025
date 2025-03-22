using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPatrol : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float detectionRange = 2.5f;

    private Transform player;
    private Vector3 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = pointB.position;
        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            // Hayalet pozisyonunu hedefe yaklaştır
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // Yönü değiştir
            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                target = target == pointA.position ? pointB.position : pointA.position;
                yield return new WaitForSeconds(1f); // Dönüşte bekleme efekti
            }

            // Oyuncuya yakınlık ve önünde olma kontrolü
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            bool isInFront = Vector3.Dot(transform.forward, dirToPlayer) > 0.5f;

            if (distanceToPlayer < detectionRange && isInFront)
            {   
                Debug.Log("Player detected!");
                GameManager.Instance.GameOver(); // Oyunu bitir
                Debug.Log("☠️ Ghost caught the player!");
                yield break;
            }

            yield return null;
        }
    }
}
