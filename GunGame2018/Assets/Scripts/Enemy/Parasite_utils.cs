using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasite_utils : Enemy_utils {

    public override void die()
    {
        GetComponent<Health_controller>().enabled = false;
        GetComponent<Enemy_attackMovement>().enabled = false;
        //GetComponent<BoxCollider2D>().enabled = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        rb.freezeRotation = false;
        rb.velocity = Vector3.forward * GetComponent<Enemy_attackMovement>().getDieSpeed();
        transform.parent = null;
    }

}
