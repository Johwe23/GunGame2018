using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shooter : MonoBehaviour {

    private GameObject player;
    private GameObject hand;
    private Enemy_gun gun;
    private Vector3 shootDirection;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        hand = transform.GetChild(0).transform.GetChild(0).gameObject;
        gun = hand.transform.GetChild(0).GetComponent<Enemy_gun>();

    }
	
	// Update is called once per frame
	void Update () {
        shootDirection = new Vector3(0, 0, Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg + 180);

        if(player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            hand.transform.eulerAngles = shootDirection + new Vector3(0, 0, 180);
            gun.setRotation(shootDirection);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
            hand.transform.eulerAngles = shootDirection;
            gun.setRotation(shootDirection);
        }

    }

    
    public Vector3 getDirection()
    {
        return shootDirection;
    }
    
}
