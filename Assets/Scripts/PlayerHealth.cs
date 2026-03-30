using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Required for Coroutines

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    // Array to hold the 3 cherry UI images
    public Image[] cherryImages;
    public GameObject gameOverPanel;

    // Variables for the blinking effect
    private bool isBlinking = false;
    private Coroutine blinkingCoroutine;
    public float blinkInterval = 0.2f; // Speed of the blink (lower is faster)

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Enemy"))
        {
            TakeDamage();
        }
        else if (other.CompareTag("HealthPack"))
        {
            Heal();
            Destroy(other.gameObject);
        }
    }

    void TakeDamage()
    {
        currentHealth--;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Heal()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            UpdateHealthUI();
        }
    }

    void UpdateHealthUI()
    {
        // 1. Stop blinking first (in case the player healed)
        StopBlinking();

        // 2. Show/hide cherry images based on current health
        for (int i = 0; i < cherryImages.Length; i++)
        {
            if (i < currentHealth)
            {
                cherryImages[i].enabled = true; // Show the image
            }
            else
            {
                cherryImages[i].enabled = false; // Hide the image
            }
        }

        // 3. If health drops to 1, start blinking the last cherry
        if (currentHealth == 1)
        {
            StartBlinking();
        }
    }

    // Function to start the blinking effect
    void StartBlinking()
    {
        if (!isBlinking && currentHealth == 1)
        {
            isBlinking = true;
            blinkingCoroutine = StartCoroutine(BlinkRoutine());
        }
    }

    // Function to stop the blinking effect
    void StopBlinking()
    {
        if (isBlinking)
        {
            isBlinking = false;
            StopCoroutine(blinkingCoroutine);

            // Ensure the last cherry is permanently visible
            if (currentHealth >= 1)
            {
                cherryImages[0].enabled = true;
            }
        }
    }

    // Coroutine for the actual blinking effect
    IEnumerator BlinkRoutine()
    {
        // Since currentHealth == 1, the first cherry (Element 0) will blink
        Image lastCherry = cherryImages[0];

        while (isBlinking)
        {
            // Toggle the image visibility
            lastCherry.enabled = !lastCherry.enabled;

            // Wait for a short duration
            yield return new WaitForSecondsRealtime(blinkInterval);
        }
    }

    void Die()
    {
        StopBlinking(); // Stop blinking when the player dies
        Time.timeScale = 0f;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}