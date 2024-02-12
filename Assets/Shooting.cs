using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public float firePointDistance = 1f;
    public float shootCooldown = 0.5f;
    private float shootTimer = 0f;
    [SerializeField] private Transform shootingPosition;

    void Update()
    {
        // Update the shoot timer
        shootTimer -= Time.deltaTime;

        // Check if the shoot timer has reached zero and the shoot key is pressed
        if (shootTimer <= 0f && Input.GetMouseButton(0))
        {
            Shoot();
            // Reset the shoot timer to the cooldown duration
            shootTimer = shootCooldown;
        }
    }

    
    void Shoot()
    {
        // Get the player's position
        Vector3 playerPosition = transform.position;

        // Get player's velocity
        //Vector3 playerVelocity = GetComponent<PlayerMovement>().GetPlayerVelocity();

        // Calculate direction to mouse pointer
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - playerPosition).normalized;

        // Calculate the position of the fire point at the edge of the player's object
        Vector3 firePointPosition = playerPosition + (direction * firePointDistance);

        // Calculate rotation angle from direction vector
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        // Instantiate projectile at the calculated fire point position with the calculated rotation
        GameObject projectile = Instantiate(projectilePrefab, shootingPosition.position, rotation); 


        // Set velocity of projectile
        //Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
        //if (projectileRB != null)
        //{
            // Subtract player's velocity from projectile's velocity
            //projectileRB.velocity = playerVelocity + (direction * projectileSpeed);
        //}

    }
}
