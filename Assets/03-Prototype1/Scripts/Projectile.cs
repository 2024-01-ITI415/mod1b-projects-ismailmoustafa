using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float destroyYThreshold = -14f;

    private Vector3 direction;

    private void Update()
    {
        // Move the projectile in its direction
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (transform.position.y < destroyYThreshold)
        {
            // Destroy the projectile
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the projectile collides with a target
        if (other.CompareTag("Target"))
        {
            // Destroy the target object
            Destroy(other.gameObject);

            // Update the score using ScoreManager
            FindObjectOfType<ScoreManager>().IncrementScore(100);
        }
    }
}
