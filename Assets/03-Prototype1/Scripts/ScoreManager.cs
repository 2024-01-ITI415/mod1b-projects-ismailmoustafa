using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Reference to the UI text component displaying the score
    private int score = 0; // Variable to store the score

    private void Start()
    {
        // Initialize the score UI
        UpdateScoreUI();
    }

    public void IncrementScore(int amount)
    {
        // Increment the score by the specified amount
        score += amount;

        // Update the score UI
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        // Update the score text UI with the current score value
        scoreText.text = "Score: " + score.ToString();
    }
}
