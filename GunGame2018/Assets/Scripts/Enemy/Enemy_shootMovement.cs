﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shootMovement : MonoBehaviour {

    private GameObject player;
    private Enemy_gun gun;
    private Animator animator;

    private bool idle;

    public float speed;
    private float currentSpeed;

    public float moveBackDistance;
    public float moveForwardDistance;
    public float idleDistance;

    public float animationFactor;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        GameObject hand = transform.GetChild(0).transform.GetChild(0).gameObject;
        gun = hand.transform.GetChild(0).GetComponent<Enemy_gun>();

        animator = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        Transform transform = GetComponentInParent<Transform>();

        if (player.transform.position.x > transform.position.x)
        {
            currentSpeed = speed;
        }
        else
        {
            currentSpeed = -speed;
        }

        if (!GetComponent<Enemy_die>().isDead())
        {
            move();
        }
                
    }

    void move()
    {
        gun.setIdle(false);
        animator.SetBool("moving", true);

        if ((player.transform.position - transform.position).magnitude < moveBackDistance)
        {
            transform.Translate(new Vector3(-currentSpeed * Time.deltaTime, 0, 0));
        }
        else if ((player.transform.position - transform.position).magnitude > idleDistance)
        {
            gun.setIdle(true);
            animator.SetBool("moving", false);
        }
        else if ((player.transform.position - transform.position).magnitude > moveForwardDistance)
        {
            transform.Translate(new Vector3(currentSpeed * Time.deltaTime, 0, 0));
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

}
