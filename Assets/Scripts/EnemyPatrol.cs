using System.Collections;
using UnityEngine;

public class EnemyPatrol2D : MonoBehaviour
{
    public Transform[] waypoints; // Array to hold the waypoints
    public float speed = 2.0f; // Speed of the patrol
    public float waitTime = 2.0f; // Time to wait at each waypoint

    private int currentWaypointIndex = 0; // Index of the current waypoint
    private bool isWaiting = false; // To track if the enemy is currently waiting
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        if (waypoints.Length > 0)
        {
            StartCoroutine(Patrol());
        }
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            if (!isWaiting)
            {
                MoveTowardsWaypoint();
                // Check if the enemy has reached the waypoint
                if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
                {
                    StartCoroutine(WaitAtWaypoint());
                }
            }
            yield return null; // Wait for the next frame
        }
    }

    void MoveTowardsWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        // Calculate the direction to the current waypoint
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        float step = speed * Time.deltaTime; // Move speed per frame

        // Flip the sprite based on movement direction
        FlipSprite(direction.x);

        // Move the enemy towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, step);
    }

    void FlipSprite(float directionX)
    {
        if (directionX > 0)
        {
            spriteRenderer.flipX = false; // Facing right
        }
        else if (directionX < 0)
        {
            spriteRenderer.flipX = true; // Facing left
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime); // Wait for the specified time
        isWaiting = false;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Move to the next waypoint
    }
}