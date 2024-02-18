using UnityEngine;

public class ScoreDetector : MonoBehaviour
{
    public int score = 0; // Holds the current score

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basketball")) //
        {
            score++;
            Debug.Log("Score! Total: " + score); // Display the score in the console
        }
    }
}
