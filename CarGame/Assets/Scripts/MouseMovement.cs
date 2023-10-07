using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity=100f;
    public GameManager manager;
    private float moveX;
    private float moveY;
    private void Update()
    {
        if(manager.stateNumber == 2)
        {
            FixedMouseMovement();
            manager.stateNumber = 4;
        }
        else if (manager.stateNumber == 0 || manager.stateNumber == 1 || manager.stateNumber == 3)
        {
            FreeMouseMovement();
        }
    }
    private void FreeMouseMovement()
    {
        Cursor.lockState = CursorLockMode.Locked;
        moveX += Input.GetAxis("Mouse Y") * -mouseSensitivity * Time.deltaTime;
        moveY += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        moveX = Mathf.Clamp(moveX, -30, 30);
        moveY = Mathf.Clamp(moveY, -60, 60);

        transform.rotation = transform.parent.rotation * Quaternion.Euler(moveX, moveY, 0f);
    }
    private void FixedMouseMovement()
    {
        transform.rotation = transform.parent.rotation * Quaternion.Euler(Random.Range(-25, 25), Random.Range(-40, 60), 0f);
    }
}
