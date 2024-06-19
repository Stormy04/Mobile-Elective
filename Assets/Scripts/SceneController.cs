using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private int currentSceneIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnActiveSceneChanged;
    }

    private void OnActiveSceneChanged(Scene current, Scene next)
    {
        currentSceneIndex = current.buildIndex;
    }

    public void StoreCurrentLevelIndex()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastLevel", currentSceneIndex);
        PlayerPrefs.Save();
    }

    public void LoadLastLevel()
    {
        int lastLevelIndex = PlayerPrefs.GetInt("LastLevel", 0); // Default to 0 if not found
        if (lastLevelIndex >= 0 && lastLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(lastLevelIndex);
        }
        else
        {
            Debug.LogWarning("Stored level index is out of range. Cannot load last level.");
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
