using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private int score = 0; // Start the score at 0
    public TMPro.TextMeshProUGUI scoreText; // Reference to the Score UI Text

    void Start()
    {
        UpdateScoreUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Add score only if the player passes through the "ScoreHole"
        if (other.CompareTag("ScoreHole"))
        {
            score++; // Increase score by 1
            UpdateScoreUI();
            Debug.Log("Score Increased! Current Score: " + score);
        }
    }

    void UpdateScoreUI()
    {
        // Update the UI text on the screen
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void AddScore()
    {
        score++;
        UpdateScoreUI();
    }
}