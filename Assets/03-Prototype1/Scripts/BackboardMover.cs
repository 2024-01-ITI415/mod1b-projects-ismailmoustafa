using UnityEngine;

public class BackboardMover : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the movement
    public float distance = 5.0f; // Distance to move side to side

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Remember the start position of the backboard
    }

    void Update()
    {
        // Calculate the new position
        Vector3 newPosition = startPosition;
        newPosition.z += Mathf.Sin(Time.time * speed) * distance; // Modify this line for side-to-side movement

        // Update the position of the backboard
        transform.position = newPosition;
    }
}
