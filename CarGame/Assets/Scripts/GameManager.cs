using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float changeInterval = 10f;

    [SerializeField] private AudioSource intenseBgm;
    [SerializeField] private AudioSource carIdleSound;

    public GameObject pauseMenu;
    public GameObject gameOverScreen;

    public int stateNumber;
    private float timer;
    private void Start()
    {
        StartCoroutine(ChangeState());
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape) && gameOverScreen.activeSelf == false)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }

        if (pauseMenu.activeSelf == true || gameOverScreen.activeSelf == true)
        {
            Time.timeScale = 0;
            timer = 0;
            Cursor.lockState = CursorLockMode.None;
            intenseBgm.Pause();
            carIdleSound.Pause();
        }
        else if (pauseMenu.activeSelf == false || gameOverScreen.activeSelf == false)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            intenseBgm.UnPause();
            carIdleSound.UnPause();
        }
    }
    IEnumerator ChangeState()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if(timer % changeInterval > 0 && timer % changeInterval < 1)
            {
                stateNumber = Random.Range(0, 4);
            }
        }
    }
}
