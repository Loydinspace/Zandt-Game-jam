using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Collider checkPointCollider;

    private void Awake()
    {
        checkPointCollider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming "Player" is the tag of your car GameObject
            // Store the current checkpoint position in a variable in the CarController script
            GameManager manager = other.gameObject.GetComponent<CarController>().manager;

            manager.SetCheckpoint(transform.position - new Vector3(0f, 4.5f, 0f), gameObject.name);

            checkPointCollider.enabled = false;
        }
    }
}
