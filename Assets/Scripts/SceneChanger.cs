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
        SceneController.instance.LoadLastLevel();
    }
}


