using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText; // Reference to the TextMesh Pro Text component that displays the score
    public TMP_Text scoreText2;
    public TMP_Text scoreText3;
    void Start()
    {
        UpdateScoreText();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText && scoreText2 && scoreText3 != null)
        {
            scoreText.text = "" + score;
            scoreText2.text = "" + score;
            scoreText3.text = "" + score;
        }
    }
}
