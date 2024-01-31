using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void Start()
    {
        // Destroy the projectile after 1.5 seconds
        Destroy(gameObject, 1.5f);
    }

    private void OnBecameInvisible()
    {
        // Destroy the projectile when it becomes invisible to any camera
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
        
    }
}
