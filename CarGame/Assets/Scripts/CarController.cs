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
    [SerializeField] private GameObject gameOver;

    [SerializeField] private bool isInverted = false;
    public GameManager manager;

    [SerializeField] private AudioSource stateOneSound;
    [SerializeField] private AudioSource stateTwoSound;
    [SerializeField] private AudioSource stateThreeSound;
    [SerializeField] private AudioSource carCrashSound;

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

        jumpscareOnSoundChange();

        if (manager.stateNumber == 1)
        {
            isInverted = true;
            manager.stateNumber = 4;
        }
        else if(manager.stateNumber == 2 || manager.stateNumber == 3 || manager.stateNumber == 0)
        {
            isInverted = false;
        }

        steering(isInverted);

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
    private void steering(bool isInverted)
    {
        if (isInverted)
        {
            horizontalInput = -horizontalInput;
        }

        currentRotationAngle = maxRotationAngle * horizontalInput;

        Front_L.steerAngle = currentRotationAngle;
        Front_R.steerAngle = currentRotationAngle;

    }
    private void jumpscareOnSoundChange()
    {
        if(manager.stateNumber == 1)
        {
            stateOneSound.Play();
        }
        else if(manager.stateNumber == 2)
        {
            stateTwoSound.Play();
        }
        else if(manager.stateNumber == 3)
        {
            stateThreeSound.Play();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            carCrashSound.Play();
            manager.gameOverScreen.SetActive(true);
        }
    }
}