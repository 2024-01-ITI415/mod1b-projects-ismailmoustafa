using UnityEngine;
using UnityEngine.UI; // Required for working with UI

public class ScoreManager : MonoBehaviour
{
    public static int score = 0; // Static score to access from other scripts
    public Text scoreText; // Reference to the Text component

    void Start()
    {
        score = 0; // Reset score at the start or level
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount; // Add the specified amount to the score
        UpdateScoreText(); // Update the UI
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Set the text to display the current score
    }
}
