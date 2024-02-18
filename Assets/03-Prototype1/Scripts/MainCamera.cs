using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera follows (initially the player/shooter)
    public Vector3 offset; // Initial offset from the target
    public float upwardsShift = 2f; // How much the camera shifts upwards on shoot
    public float shiftDuration = 0.5f; // Duration of the upward shift

    private Vector3 shootingOffset; // Additional offset applied when shooting
    private float shiftTimer = 0f; // Timer to track the shift duration

    void Start()
    {
        shootingOffset = Vector3.zero;
    }

    void Update()
    {
        if (shiftTimer > 0)
        {
            shiftTimer -= Time.deltaTime;
            if (shiftTimer <= 0)
            {
                shootingOffset = Vector3.zero; // Reset the shooting offset after the duration
            }
        }

        // Follow the target with the initial offset and any additional shooting offset
        transform.position = target.position + offset + shootingOffset;
    }

    // Call this method from the shooting script when the ball is shot
    public void OnShoot()
    {
        shootingOffset = Vector3.up * upwardsShift; // Apply an upward shift
        shiftTimer = shiftDuration; // Reset the timer
    }
}
