using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private GameManager manager;
    private Vector3 target;
    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        target = player.position;
        target.y = player.position.y + 2;
        transform.LookAt(target);

    }
}
