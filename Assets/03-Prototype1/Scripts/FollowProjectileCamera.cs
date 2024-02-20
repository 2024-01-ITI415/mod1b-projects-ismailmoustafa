using UnityEngine;

public class FollowProjectileCamera : MonoBehaviour
{
    public Transform projectile; // Assign this in the Inspector
    public Vector3 offset; // Offset from the projectile position
    private bool isLaunched = false;

    void Update()
    {
        if (!isLaunched)
        {
            // Follow the projectile with an offset before it's launched
            transform.position = projectile.position + offset;
        }
    }

    // Call this method when the projectile is launched
    public void ProjectileLaunched()
    {
        isLaunched = true;
    }
}
