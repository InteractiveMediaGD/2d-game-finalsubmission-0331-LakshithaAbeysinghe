using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Array to hold multiple obstacle prefabs
    public GameObject[] obstaclePrefabs;
    public float spawnRate = 2f;

    void Start()
    {
        // Start spawning obstacles repeatedly
        InvokeRepeating("SpawnObstacle", 1f, spawnRate);
    }

    void SpawnObstacle()
    {
        // Select a random obstacle from the array
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);

        // Instantiate the selected random obstacle
        Instantiate(obstaclePrefabs[randomIndex], transform.position, Quaternion.identity);
    }
}