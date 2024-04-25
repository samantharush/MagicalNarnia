using UnityEngine;

// Make sure there is no other class with the name 'ContinuousMovement' in your project.
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

    // Ensure there is only one Update method
    void Update()
    {
        if (shouldMove)
        {
            rb.MovePosition(rb.position + movementDirection.normalized * speed * Time.deltaTime);
        }
    }

    // Ensure there is only one OnCollisionEnter method
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with obstacle detected.");
            shouldMove = false;
        }
    }
}