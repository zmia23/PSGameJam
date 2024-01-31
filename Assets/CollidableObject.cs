using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Collided with the player!");
        }


        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Deactivate the object
            // gameObject.SetActive(false);
        }

    }
}
