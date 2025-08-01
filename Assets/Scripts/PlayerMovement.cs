using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Default speed of the player
    public float normalSpeed;  // Expose normal speed for potion to modify
    private Rigidbody2D rb;  // Rigidbody for physics-based movement
    private Vector2 moveInput;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        normalSpeed = moveSpeed;  // Store the normal speed for potion access
    }

    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;  // Handle player movement using velocity
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }

        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

    // Called by the potion script to apply a speed change
    public void ApplySpeedChange(float newSpeed, float duration)
    {
        moveSpeed = newSpeed; // Apply the new speed
        StartCoroutine(ResetSpeedAfterTime(duration)); // Reset speed after the duration
    }

    private System.Collections.IEnumerator ResetSpeedAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);  // Wait for the specified time
        moveSpeed = normalSpeed;  // Reset back to normal speed
    }
}
