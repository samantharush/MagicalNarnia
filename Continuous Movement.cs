using UnityEngine;

public class ContinuousMovement : MonoBehaviour
{
    public Vector3 movementDirection = Vector3.forward;
    public float speed = 5.0f;
    private bool shouldMove = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody component found. Adding one.");
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }
    }

    void Update()
    {
        if (shouldMove)
        {
            rb.MovePosition(rb.position + movementDirection.normalized * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with obstacle detected.");
            shouldMove = false;
        }
    }
}
