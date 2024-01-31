using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    // Called when the player collides with another collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player collides with an obstacle, react accordingly
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Debug.Log("Player collided with obstacle!");

            // Stop the player's movement 
            PlayerMovement movement = GetComponent<PlayerMovement>();
            if (movement != null)
            {
                movement.StopMovement();
            }

            // Performing other actions based on the collision
            // Reducing health, playing sound effects, etc.
        }
    }
}
