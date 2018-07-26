using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Org_utils : Enemy_utils {

    public override void die()
    {
        GetComponent<Enemy_shooter>().enabled = false;
        GetComponent<Health_controller>().enabled = false;
        GetComponent<Enemy_shootMovement>().enabled = false;
        transform.GetComponentInChildren<Transform>().GetComponentInChildren<Enemy_head_controller>().enabled = false;
        transform.GetComponentInChildren<Transform>().GetComponentInChildren<Transform>().GetComponentInChildren<Enemy_gun>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
