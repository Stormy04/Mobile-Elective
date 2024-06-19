using UnityEngine;
using UnityEngine.UI;

public class GamePauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Reference to the Pause Menu UI Panel
    private bool isPaused = false;  // Boolean to track whether the game is paused

    void Start()
    {
        if (pauseMenuUI == null)
        {
            Debug.LogError("pauseMenuUI is not assigned in the Inspector!");
        }
        else
        {
            isPaused = false; // Ensure the pause menu starts hidden
        }
    }


    // Method to handle the pause button click
    public void OnPauseButtonClicked()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    // Method to pause the game
    private void PauseGame()
    {
        pauseMenuUI.SetActive(true);  // Show the pause menu
        Time.timeScale = 0f;          // Freeze the game
        isPaused = true;              // Set the pause state to true
    }

    // Method to resume the game
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f;          // Unfreeze the game
        isPaused = false;             // Set the pause state to false
    }

}
