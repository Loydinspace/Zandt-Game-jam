using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadSceneAsync(1);
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
