using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    //private float rotateY;

    [SerializeField] private WheelCollider Back_L;
    [SerializeField] private WheelCollider Back_R;
    [SerializeField] private WheelCollider Front_L;
    [SerializeField] private WheelCollider Front_R;
    //[SerializeField] private Transform steeringWheel;

    public float acceleration = 100f;
    public float brakeForce = 100f;
    public float maxRotationAngle = 30f;
    //public float steerWheelRotationSpeed = 2;

    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentRotationAngle = 0f;
    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        move();
        steering();
    }
    private void move()
    {
        currentAcceleration = acceleration * verticalInput;
        if (Input.GetKey(KeyCode.Space))
        {
            currentBrakeForce = brakeForce;
        }
        else
        {
            currentBrakeForce = 0f;
        }

        Back_L.brakeTorque = currentBrakeForce;
        Back_R.brakeTorque = currentBrakeForce;
        Back_L.motorTorque = currentAcceleration;
        Back_R.motorTorque = currentAcceleration;
    }
    private void steering()
    {
        currentRotationAngle = maxRotationAngle * horizontalInput;
        //rotateY += steerWheelRotationSpeed * horizontalInput * Time.deltaTime;

        //steeringWheel.rotation = transform.rotation * steeringWheel.up * Quaternion.Euler(0f, rotateY, 0f);

        Front_L.steerAngle = currentRotationAngle;
        Front_R.steerAngle = currentRotationAngle;
    }
}