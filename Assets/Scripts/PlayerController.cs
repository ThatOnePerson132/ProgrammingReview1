using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float horizontalInput;
    public float verticalInput;
    public GameManager gm;
    public float Lives;
    public CircleCollider2D cc;
    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CircleCollider2D>();
        gm = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
        Lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveSpeed * horizontalInput * Time.deltaTime);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * moveSpeed * verticalInput * Time.deltaTime);
       // animator.SetFloat("moveSpeed", Mathf.Abs(horizontalInput));
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(gm.Hurt());
        }
    }


}
