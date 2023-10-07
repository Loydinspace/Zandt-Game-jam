using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity=100f;
    private float moveX;
    private float moveY;
    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        moveX += Input.GetAxis("Mouse Y") * -mouseSensitivity * Time.deltaTime;
        moveY += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        moveX = Mathf.Clamp(moveX, -30, 30);
        moveY = Mathf.Clamp(moveY, -60, 60);

        transform.rotation = transform.parent.rotation * Quaternion.Euler(moveX, moveY, 0f);
    }
}
