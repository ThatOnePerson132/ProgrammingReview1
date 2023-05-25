using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject player;  
    public float moveSpeed = 5f;  

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); // Assumes player tag is "Player"
    }

    private void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (player != null)
        {
            Vector2 moveDirection = (player.transform.position - transform.position).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

}
