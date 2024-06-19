using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void RestartCurrentLevel()
    {

        Scene currentScene = SceneManager.GetActiveScene();
         SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }
   
  

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        SceneController.instance.LoadLastLevel();
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }
}



