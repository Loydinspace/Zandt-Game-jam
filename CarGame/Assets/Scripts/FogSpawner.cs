using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FogSpawner : MonoBehaviour
{
    [SerializeField] private GameObject smallFogReference;

    [SerializeField] private float minSpawnDistanceZ = 10f;
    [SerializeField] private float maxSpawnDistanceZ = 20f;
    [SerializeField] private float minSpawnDistanceX = -2f;
    [SerializeField] private float maxSpawnDistanceX = 2f;

    [HideInInspector] public float minSpawnTime = 30f;
    [HideInInspector] public float maxSpawnTime = 35f;

    GameObject smallFog;
    private void Start()
    {
        StartCoroutine(startSpawn());
    }

    IEnumerator startSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime,maxSpawnTime));

            float spawnDistanceZ = Random.Range(minSpawnDistanceZ, maxSpawnDistanceZ);
            float spawnDistanceX = Random.Range(minSpawnDistanceX, maxSpawnDistanceX);

            smallFog = Instantiate(smallFogReference);

            transform.rotation *= Quaternion.Euler(new Vector3(0f, spawnDistanceX, 0f));
            smallFog.transform.position = transform.position + transform.forward * spawnDistanceZ;

            Destroy(smallFog, 10f);
        }
    }
}
