using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    public GameObject levelCompleteUI; // Drag your UI canvas here in Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Make sure your Player GameObject is tagged "Player"
        {
            if (levelCompleteUI != null)
            {
                levelCompleteUI.SetActive(true);
                Time.timeScale = 0f; // Pause game
            }
        }
    }
}