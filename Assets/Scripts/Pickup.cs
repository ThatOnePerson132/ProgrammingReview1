using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public SpriteRenderer sr;
    public BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        bc = gameObject.GetComponent<BoxCollider2D>();
        ChildStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Activate()
    {

    }

    public virtual void ChildStart()
    {

    }

    IEnumerator DelayedDestroy()
    {
        sr.enabled = false;
        bc.enabled = false;
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           Activate();
           StartCoroutine(DelayedDestroy());
        }

    }
}
