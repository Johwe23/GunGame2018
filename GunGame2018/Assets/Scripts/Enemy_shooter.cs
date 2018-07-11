using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shooter : MonoBehaviour {

    private GameObject player;
    private GameObject hand;
    private Enemy_gun gun;
    private Vector3 shootDirection;
    private bool idle;

    public float speed;
    private float currentSpeed;

    public float moveBackDistance;
    public float moveForwardDistance;
    public float idleDistance;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        hand = transform.GetChild(0).gameObject;
        gun = hand.transform.GetChild(0).GetComponent<Enemy_gun>();

    }
	
	// Update is called once per frame
	void Update () {
        shootDirection = new Vector3(0, 0, Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg + 180);

        if(player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            hand.transform.eulerAngles = shootDirection + new Vector3(0, 0, 180);
            gun.setRotation(shootDirection);
            currentSpeed = speed;
        } else
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
            hand.transform.eulerAngles = shootDirection;
            gun.setRotation(shootDirection);
            currentSpeed = -speed;
        }

        gun.setIdle(false);
        if ((player.transform.position - transform.position).magnitude < moveBackDistance)
        {
            transform.Translate(new Vector3(-currentSpeed * Time.deltaTime, 0, 0));
        }
        else if((player.transform.position - transform.position).magnitude > idleDistance){
            gun.setIdle(true);
        }
        else if ((player.transform.position - transform.position).magnitude > moveForwardDistance )
        {
            transform.Translate(new Vector3(currentSpeed * Time.deltaTime, 0, 0));
        }


    }

    

    
}
