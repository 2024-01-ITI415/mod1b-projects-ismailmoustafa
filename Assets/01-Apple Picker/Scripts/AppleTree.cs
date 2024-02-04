using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 20f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;
    public float dropHeight = 25f; // New variable to control drop height

    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        // Modified to adjust the Y position where the apple spawns
        Vector3 dropPosition = new Vector3(transform.position.x, transform.position.y + dropHeight, transform.position.z);
        Instantiate(applePrefab, dropPosition, Quaternion.identity);
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
