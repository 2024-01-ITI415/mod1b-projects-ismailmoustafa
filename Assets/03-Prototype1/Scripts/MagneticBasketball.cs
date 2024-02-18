using UnityEngine;

public class MagneticBasketball : MonoBehaviour
{
    public Transform basketTarget; // Assign the basket's rim Transform in the Inspector
    public float attractionDistance = 5f; // Distance within which the magnetic effect starts
    public float magneticForce = 10f; // Strength of the magnetic attraction

    private Rigidbody rb; // Rigidbody of the basketball

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (basketTarget == null) return;

        float distanceToBasket = Vector3.Distance(transform.position, basketTarget.position);
        if (distanceToBasket <= attractionDistance)
        {
            Vector3 directionToBasket = (basketTarget.position - transform.position).normalized;
            // Apply a force towards the basket
            rb.AddForce(directionToBasket * magneticForce * (1 - distanceToBasket / attractionDistance));
        }
    }
}
