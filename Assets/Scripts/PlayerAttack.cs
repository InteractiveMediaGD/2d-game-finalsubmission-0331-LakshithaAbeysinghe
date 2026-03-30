using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;

    void Update()
    {
        // When the left mouse button (0) is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Instantiate a new bullet at the player's current position
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}