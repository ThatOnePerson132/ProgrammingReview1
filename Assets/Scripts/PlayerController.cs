using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float horizontalInput;
    public float verticalInput;
    public GameManager gm;
    public SpriteRenderer sr;
    public CircleCollider2D cc;
    public float Lives;
    public bool isPowered = false;
    public Sprite baseFace;
    public Sprite angryFace;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
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
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(gm.Hurt());
        }

        if (isPowered == true && collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(GameObject.Find("Enemy")); 
        }
    }


}
