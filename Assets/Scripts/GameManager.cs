using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton Instance
    public static GameManager instance;

    void Awake()
    {
        // Initialize the Singleton instance
        if (instance == null)
        {
            instance = this;
        }
    }

    public float globalSpeed = 5f;
    public float speedIncreaseRate = 0.2f;

    void Update()
    {
        // Gradually increase the global speed over time
        globalSpeed += speedIncreaseRate * Time.deltaTime;
    }

    public void RestartGame()
    {
        // Reset the time scale and reload the current scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}