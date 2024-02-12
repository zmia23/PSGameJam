using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    private void Start()
    {
        // Destroy the projectile after 1.5 seconds
        Destroy(gameObject, 1.5f);
    }
    private void Update()
    {
        transform.position += transform.up * projectileSpeed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        // Destroy the projectile when it becomes invisible to any camera
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {

        if (collision.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
        
    }
}
