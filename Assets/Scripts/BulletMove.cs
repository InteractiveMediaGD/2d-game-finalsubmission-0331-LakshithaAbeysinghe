using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet

    void Start()
    {
        // Destroy the bullet automatically after 3 seconds (Short duration)
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // Move the bullet to the right
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the bullet hits an obstacle, destroy only the bullet
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        // If the bullet hits an enemy...
        else if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the bullet

            // Find the PlayerScore script and add score
            PlayerScore ps = FindObjectOfType<PlayerScore>();
            if (ps != null)
            {
                ps.AddScore();
            }
        }
    }
}