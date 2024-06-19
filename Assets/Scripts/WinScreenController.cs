using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreenController : MonoBehaviour
{
    public Button nextLevelButton;

    private void Start()
    {
        nextLevelButton.onClick.AddListener(LoadNextLevel);
    }

    void LoadNextLevel()
    {
        int nextLevelIndex = PlayerPrefs.GetInt("ReachedIndex", 1);

        // Make sure the next level index is within the range of available scenes
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.Log("No more levels to load!");
        }
    }
}
