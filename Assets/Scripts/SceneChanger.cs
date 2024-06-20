using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public void RestartCurrentLevel()
    {

        Scene currentScene = SceneManager.GetActiveScene();
         SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }
   
  

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        pauseMenuUI.SetActive(false);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }
}



