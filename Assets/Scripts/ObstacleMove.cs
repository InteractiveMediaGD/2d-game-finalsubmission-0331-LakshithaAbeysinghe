using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    void Update()
    {
        // Move to the left using the global speed from the GameManager Singleton
        transform.Translate(Vector2.left * GameManager.instance.globalSpeed * Time.deltaTime);

        // Destroy the obstacle when it goes off-screen to save memory
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}