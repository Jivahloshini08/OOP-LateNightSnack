using UnityEngine;

public class Food : MonoBehaviour
{
    public int scoreValue = 10; // You can set this per food

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add score to player
            ScoreManager.instance.AddScore(scoreValue);

            // Destroy the food object
            Destroy(gameObject);
        }
    }
}
