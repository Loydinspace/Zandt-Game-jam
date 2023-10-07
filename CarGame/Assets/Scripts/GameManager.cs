using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float changeInterval = 10f;
    public int stateNumber;
    private void Start()
    {
        StartCoroutine(ChangeState());
    }
    IEnumerator ChangeState()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);
            stateNumber = Random.Range(0, 4);
        }
    }
}
