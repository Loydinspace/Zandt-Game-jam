using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    public void playGame()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1f;
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void exitToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
