using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attackMovement : MonoBehaviour {

    private GameObject player;
    private Animator animator;
    private Rigidbody2D rb;

    public float speed;
    private float currentSpeed;
    public float jumpSpeed;
    public float dieSpeed;
    private bool attached;

    public float idleDistance;
    public float jumpDistance;
    public float attachDistance;
    private bool jumped = false;

    public float animationFactor;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");

        animator = GetComponentInChildren<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (!attached)
        {
            move();
        }
        else
        {

        }
        
    }

    void move()
    {

        if (player.transform.position.x > transform.position.x)
        {
            currentSpeed = speed;
        }
        else
        {
            currentSpeed = -speed;
        }

        animator.SetBool("moving", true);

        if ((player.transform.position - transform.position).magnitude > idleDistance)
        {
            animator.SetBool("moving", false);
        }
        else if ((player.transform.position - transform.position).magnitude > jumpDistance)
        {
            transform.Translate(new Vector3(currentSpeed * Time.deltaTime, 0, 0));
            jumped = false;
        }
        else 
        {
            transform.Translate(new Vector3(currentSpeed * Time.deltaTime, 0, 0));
            if (!jumped || rb.velocity.y == 0)
            {
                rb.velocity = Vector3.up * jumpSpeed;
                jumped = true;
                animator.SetBool("jumping", true);
            }
            else
            {
                animator.SetBool("jumping", false);
            }

            if((player.transform.position - transform.position).magnitude < attachDistance)
            {
                grab();
                animator.SetBool("grabing", true);
            }
        }
    }

    void grab()
    {
        attached = true;
        gameObject.transform.parent = player.transform;
        rb.isKinematic = true;
        rb.velocity = new Vector3(0, 0, 0);
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((transform.position.y), (transform.position.x)) * Mathf.Rad2Deg - 90);
    }

    public float getDieSpeed()
    {
        return dieSpeed;
    }
}
