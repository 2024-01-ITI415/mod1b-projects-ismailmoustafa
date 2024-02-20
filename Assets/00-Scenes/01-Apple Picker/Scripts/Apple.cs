using UnityEngine;

public class Apple : MonoBehaviour
{
    void Start()
    {
        // Optionally set initial velocity or other properties
    }

    void Update()
    {
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }
}
