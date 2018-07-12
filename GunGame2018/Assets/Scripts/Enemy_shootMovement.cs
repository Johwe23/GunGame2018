using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shootMovement : MonoBehaviour {

    private GameObject player;
    private Enemy_gun gun;

    private bool idle;

    public float speed;
    private float currentSpeed;

    public float moveBackDistance;
    public float moveForwardDistance;
    public float idleDistance;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        GameObject hand = transform.GetChild(0).gameObject;
        gun = hand.transform.GetChild(0).GetComponent<Enemy_gun>();
    }
	
	// Update is called once per frame
	void Update () {


        if (player.transform.position.x > transform.position.x)
        {
            currentSpeed = speed;
        }
        else
        {
            currentSpeed = -speed;
        }

        gun.setIdle(false);
        if ((player.transform.position - transform.position).magnitude < moveBackDistance)
        {
            transform.Translate(new Vector3(-currentSpeed * Time.deltaTime, 0, 0));
        }
        else if ((player.transform.position - transform.position).magnitude > idleDistance)
        {
            gun.setIdle(true);
        }
        else if ((player.transform.position - transform.position).magnitude > moveForwardDistance)
        {
            transform.Translate(new Vector3(currentSpeed * Time.deltaTime, 0, 0));
        }
    }
}
