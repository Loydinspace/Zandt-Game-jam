using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private WheelCollider Back_L;
    [SerializeField] private WheelCollider Back_R;
    [SerializeField] private WheelCollider Front_L;
    [SerializeField] private WheelCollider Front_R;
    public GameManager manager;

    public float acceleration = 100f;
    public float brakeForce = 100f;
    public float maxRotationAngle = 30f;

    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentRotationAngle = 0f;
    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        move();
        if (manager.stateNumber == 1)
        {
            invertedSteering();
        }
        else
        {
            steering();
        }
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

        if(Back_L.rpm > 500f)
        {
            currentAcceleration = 0f;
        }
        Back_L.brakeTorque = currentBrakeForce;
        Back_R.brakeTorque = currentBrakeForce;
        Front_L.motorTorque = currentAcceleration;
        Front_R.motorTorque = currentAcceleration;
        Back_L.motorTorque = currentAcceleration;
        Back_R.motorTorque = currentAcceleration;
    }
    private void steering()
    {
        currentRotationAngle = maxRotationAngle * horizontalInput;

        Front_L.steerAngle = currentRotationAngle;
        Front_R.steerAngle = currentRotationAngle;

    }
    private void invertedSteering()
    {
        currentRotationAngle = maxRotationAngle * -horizontalInput;

        Front_L.steerAngle = currentRotationAngle;
        Front_R.steerAngle = currentRotationAngle;
    }
}