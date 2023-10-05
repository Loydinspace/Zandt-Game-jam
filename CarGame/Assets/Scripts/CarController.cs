using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float carSpeed = 200f;
    [SerializeField] private float maxSpeed = 100f;
    [SerializeField] private float maxReverseSpeed = 50f;
    [SerializeField] private float rotatingSpeed = 5f;
    private Vector3 forward;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(transform.forward * carSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(-transform.forward * carSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
}
