using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves
    public Vector3 direction; // Direction of the player's movement

    public float gravity = -9.8f; // Gravity affecting the player
    public float jumpStrength = 5f; // Strength of the player's jump
    private bool isGrounded; // Whether the player is on the ground/platform

    void Start()
    {
        direction = Vector3.right; // Assuming the player moves to the right
    }

    void Update()
    {
        // Continuous movement
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Jumping
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            direction.y = jumpStrength;
            isGrounded = false; // Player is no longer grounded once they jump
        }

        // Apply gravity if the player is not grounded
        if (!isGrounded)
        {
            direction.y += gravity * Time.deltaTime;
        }

        // Apply the direction to the player's position
        transform.position += direction * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player has collided with a platform
        if (collision.gameObject.tag == "Platform") // Ensure your platforms are tagged appropriately
        {
            isGrounded = true; // Player is now grounded
            direction.y = 0; // Stop any vertical movement
        }
    }
}