using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : Pickup
{
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        pc.isPowered = true;
        pc.sr.sprite = pc.angryFace;
        new WaitForSeconds(5);
        pc.isPowered = false;
        pc.sr.sprite = pc.baseFace;
    }
}
