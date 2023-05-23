using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform player;  // Reference to the player object
    public float moveSpeed = 5f;  // Enemy movement speed

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assumes player tag is "Player"
    }

    private void Update()
    {
        FindPlayer();

        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = player.position - transform.position;

            // Normalize the direction vector
            direction.Normalize();

            // Calculate the enemy's movement velocity
            Vector2 velocity = direction * moveSpeed;

            // Apply the velocity to the enemy's rigidbody
            rb.velocity = velocity;
        }

    }
    private void FindPlayer()
    {
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player"); // Assumes player tag is "Player"
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
    }
}
