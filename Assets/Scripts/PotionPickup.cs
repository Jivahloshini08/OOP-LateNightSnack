using UnityEngine;

public class Potion : MonoBehaviour
{
    public enum EffectType { SpeedUp, SlowDown }
    public EffectType effectType;
    public float effectDuration = 10f;  // Duration for which the effect lasts
    public float speedMultiplier = 2f; // How much faster/slower the player will go

    private void OnTriggerEnter2D(Collider2D other)  // Use 2D collision if you have a 2D game
    {
        if (other.CompareTag("Player"))  // Ensure the tag on your player is "Player"
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                float newSpeed = (effectType == EffectType.SpeedUp)
                    ? player.normalSpeed * speedMultiplier
                    : player.normalSpeed / speedMultiplier;

                player.ApplySpeedChange(newSpeed, effectDuration); // Apply the effect
                Destroy(gameObject); // Destroy the potion after being consumed
            }
        }
    }
}
