using UnityEngine;

public class BasketballShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your basketball prefab in the Inspector
    public CameraFollow cameraFollowScript; // Assign your CameraFollow script attached to the camera in the Inspector
    public float shootingForce = 1000f;
    public float moveSpeed = 5f; // Speed at which the shooter moves

    void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // Get horizontal input
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // Get vertical input

        // Apply movement
        transform.Translate(moveX, 0, moveZ);

        // Shooting with mouse click
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            ShootBasketballTowardsClick();
        }
    }

    void ShootBasketballTowardsClick()
    {
        if (projectilePrefab != null)
        {
            // Convert mouse click position to a ray from the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Vector3 targetPosition;
            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;
            }
            else
            {
                targetPosition = ray.GetPoint(1000); // Example distance
            }

            // Instantiate the basketball prefab at this object's position
            GameObject basketball = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Ensure the basketball has a Rigidbody component
            Rigidbody rb = basketball.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = basketball.AddComponent<Rigidbody>();
            }

            // Calculate the direction from the shooter to the target position
            Vector3 shootingDirection = targetPosition - transform.position;
            shootingDirection = shootingDirection.normalized;

            // Add an upward force to simulate the arc of a real basketball shot
            Vector3 upwardForce = Vector3.up * shootingForce * 0.3f; // Adjust the multiplier to get the desired arc

            // Apply forces to shoot the basketball
            rb.AddForce(shootingDirection * shootingForce + upwardForce);

            // Apply a rotational torque to simulate the basketball's spin
            rb.AddTorque(transform.forward * -1000); // Adjust the torque value to get the desired spin

            // Notify the camera to shift upwards
            if (cameraFollowScript != null)
            {
                cameraFollowScript.OnShoot();
            }
        }
    }
}
