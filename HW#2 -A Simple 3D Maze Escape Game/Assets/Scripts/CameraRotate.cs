using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float mouseX;
    [SerializeField] private float mouseY;
    [SerializeField] private float minLimit;
    [SerializeField] private float maxLimit;

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X"); // sağ sol tutuyoruz
        mouseY = Input.GetAxis("Mouse Y");

        transform.eulerAngles += new Vector3(0, mouseX * rotationSpeed * Time.deltaTime, 0);
        transform.eulerAngles -= new Vector3(mouseY * rotationSpeed * Time.deltaTime, 0, 0);

        float startValue = transform.eulerAngles.x;

        if (180 < startValue && startValue < minLimit)
        {
            transform.eulerAngles = new Vector3(minLimit, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        if (maxLimit < startValue && startValue < 180)
        {
            transform.eulerAngles = new Vector3(maxLimit, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
