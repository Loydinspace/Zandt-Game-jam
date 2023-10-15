using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float changeInterval = 10f;

    [SerializeField] private AudioSource intenseBgm;
    [SerializeField] private AudioSource carIdleSound;

    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public GameObject storyScreen;
    public GameObject endScreen;

    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    [SerializeField] StoryPanel storyPanel;
    [SerializeField] FogSpawner littleFog;

    private Vector3 checkPointPosition;
    private string currentCheckPoint;

    public int stateNumber = 4;
    private int maxStateNumber = 1;

    private void Awake()
    {
        checkPointPosition = player.transform.position;
    }

    private void Start()
    {
        StartCoroutine(ChangeState());
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && gameOverScreen.activeSelf == false && storyScreen.activeSelf == false && endScreen.activeSelf == false)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }

        if (pauseMenu.activeSelf == true || gameOverScreen.activeSelf == true || storyScreen.activeSelf == true || endScreen.activeSelf == true)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            intenseBgm.Pause();
            carIdleSound.Pause();
        }
        else if (pauseMenu.activeSelf == false || gameOverScreen.activeSelf == false || storyScreen.activeSelf == false || endScreen.activeSelf == false)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            intenseBgm.UnPause();
            carIdleSound.UnPause();
        }

        switch (currentCheckPoint)
        {
            case "Road Signs 1":
                storyPanel.currentStoryIndex = 1;
                maxStateNumber = 2;
                littleFog.minSpawnTime = 25f;
                littleFog.maxSpawnTime = 30f;
                break;
            case "Road Signs 2":
                storyPanel.currentStoryIndex = 2;
                maxStateNumber = 3;
                littleFog.minSpawnTime = 20f;
                littleFog.maxSpawnTime = 25f;
                break;
            case "Road Signs 3":
                storyPanel.currentStoryIndex = 3;
                maxStateNumber = 4;
                littleFog.minSpawnTime = 15f;
                littleFog.maxSpawnTime = 20f;
                break;
            case "Road Signs 4":
                storyPanel.currentStoryIndex = 4;
                littleFog.minSpawnTime = 10f;
                littleFog.maxSpawnTime = 15f;
                break;
        }
    }
    IEnumerator ChangeState()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);

            stateNumber = Random.Range(0, maxStateNumber);
        }
    }
    public void SetCheckpoint(Vector3 position,string name)
    {
        checkPointPosition = position;
        currentCheckPoint = name;
        storyPanel.gameObject.SetActive(true);
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void reloadCheckpoint()
    {
        player.transform.position = checkPointPosition;
        player.transform.rotation = Quaternion.identity;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        enemy.transform.position = checkPointPosition + new Vector3(0f, 0f, -300f);

        gameOverScreen.SetActive(false);
        pauseMenu.SetActive(false);

        stateNumber = 0;
    }
}
