using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
public class FinishPoint : MonoBehaviour
{
    // Reference to the win screen UI
    [SerializeField]
    private GameObject winScreenUI;
    [SerializeField]
    private PlayerScore playerScore;
    public CarController carcontroller;
    public AudioSource winSound;
    [SerializeField]
    private GameObject pausebutton;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnlockNewLevel();
            ShowWinScreen();
            Time.timeScale = 0f; // Stop the game
            
        }
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }

    void ShowWinScreen()
    {
        winScreenUI.SetActive(true);
        if (playerScore != null && playerScore.scoreText != null)
        {
            playerScore.scoreText.gameObject.SetActive(false);
        }
        carcontroller.StopMusic();
        winSound.Play();
        pausebutton.SetActive(false);
    }

    // Method to be called by the UI button
    public void LoadNextLevel()
    {
        Time.timeScale = 1f; // Resume the game
        SceneController.instance.NextLevel();
    }
}
