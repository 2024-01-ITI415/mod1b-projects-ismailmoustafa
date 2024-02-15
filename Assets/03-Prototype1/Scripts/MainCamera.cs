using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform targetObject; // The object to move towards
    public float speed = 5f; // Speed at which the camera moves

    void Update()
    {
        if (targetObject != null)
        {
            // Move the camera directly towards the target object
            transform.position = Vector3.MoveTowards(transform.position, targetObject.position, speed * Time.deltaTime);
        }
    }
}
