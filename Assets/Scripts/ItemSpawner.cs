using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject healthPackPrefab;
    public float spawnRate = 7f;

    // Allows changing the minimum and maximum spawn height from the Inspector
    public float minY = -1f;
    public float maxY = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnItem", 3f, spawnRate);
    }

    void SpawnItem()
    {
        // Choose a random Y position between minY and maxY
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPos = new Vector2(transform.position.x, randomY);

        Instantiate(healthPackPrefab, spawnPos, Quaternion.identity);
    }
}