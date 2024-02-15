using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your projectile prefab in the inspector

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0)) // Change 0 to 1 for right mouse button, 2 for middle
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        // Get mouse position in world space
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.y; // Adjust the z-coordinate to match the camera's y position
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate direction towards mouse position
        Vector3 direction = mousePosition - transform.position;
        direction.Normalize(); // Ensure the direction vector has a magnitude of 1

        // Instantiate projectile with the calculated direction
        GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Get the projectile component and set its direction
        Projectile projectile = projectileInstance.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.SetDirection(direction);
        }
    }
}


