using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : Pickup
{
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        gm.score += 10;
    }
}
