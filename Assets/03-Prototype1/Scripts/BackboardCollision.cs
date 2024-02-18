using UnityEngine;

public class BackboardCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collider we hit is tagged as "Basketball"
        if (collision.collider.CompareTag("Basketball"))
        {
            Debug.Log("Basketball hit the backboard!");
            // Here you can add any logic you want to happen when the basketball hits the backboard
        }
    }
}
