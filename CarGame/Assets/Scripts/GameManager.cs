using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float changeInterval = 10f;
    public GameObject pauseMenu;
    public int stateNumber;
    private void Start()
    {
        StartCoroutine(ChangeState());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);

            Cursor.lockState = CursorLockMode.None;

        }

        if (pauseMenu.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else if (pauseMenu.activeSelf == false)
        {
            Time.timeScale = 1;
        }
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
