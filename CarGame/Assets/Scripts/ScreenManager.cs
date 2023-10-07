using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject LowVision;
    private GameManager manager;
    private void Awake()
    {
        manager = GetComponent<GameManager>();
    }
    private void Update()
    {
        if(manager.stateNumber == 3)
        {
            LowVision.SetActive(true);
            manager.stateNumber = 4;
        }
        else if(manager.stateNumber == 0 || manager.stateNumber == 1 || manager.stateNumber == 2)
        {
            LowVision.SetActive(false);
        }
    }
}
