using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 movementVector;

    [SerializeField] private float horizontal; // x eksenindeki hareketi tutacak (sağ-sol)
    [SerializeField] private float vertical;   // z eksenindeki hareketi tutacak (ön-arka)

    private Rigidbody rb;
    private AnimatorPlayer animatorPlayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animatorPlayer = GetComponent<AnimatorPlayer>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        movementVector = new Vector3(horizontal, 0, vertical);
        movementVector.Normalize();

        rb.MovePosition(transform.position + movementVector * speed * Time.deltaTime);

        if (movementVector != Vector3.zero) // Eğer hareket vektörü sıfırdan farklıysa, karakter hareket ediyor demektir.
        {
            animatorPlayer.SetBool("Walk", true);
        }
        else
        {
            animatorPlayer.SetBool("Walk", false);
        }
    }
}
