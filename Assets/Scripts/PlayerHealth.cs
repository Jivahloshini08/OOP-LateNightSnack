using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1;
    public int health;
    public GameObject gameOverUI; // Assign your GameOverCanvas here in Inspector

    void Start()
    {
        health = maxHealth;

        if (gameOverUI != null)
            gameOverUI.SetActive(false); // Make sure it's hidden at game start
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // Disable player movement (optional)
            Time.timeScale = 0f; // Freeze game (optional)

            if (gameOverUI != null)
                gameOverUI.SetActive(true); // Show Game Over UI
        }
    }
}