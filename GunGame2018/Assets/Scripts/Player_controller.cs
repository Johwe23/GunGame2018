using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour {


    private KeyCode right = KeyCode.D;
    private KeyCode left = KeyCode.A;
    private KeyCode jump = KeyCode.Space;

    private bool canJump = false;
    private Rigidbody2D rb;

    public float horizontalAcceleration;
    public float horizontalRetardation;
    public float maxHorizontalSpeed;
    public float minHorizontalSpeed;
    public float minRunSpeed;
    public float jumpSpeed;
    public float animationFactor;
    private float scale;
    private bool facingRight = true;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private Animator animator;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        scale = transform.localScale.x;
    }

    void FixedUpdate()
    {
        canJump = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(right) && rb.velocity.x < maxHorizontalSpeed)
        {
            rb.AddForce(new Vector2(horizontalAcceleration, 0));
            facingRight = true;
        }
        else if (Input.GetKey(left) && rb.velocity.x > -maxHorizontalSpeed)
        {
            rb.AddForce(new Vector2(-horizontalAcceleration, 0));
            facingRight = false;
        }
        else if (Mathf.Abs(rb.velocity.x) < minHorizontalSpeed)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            rb.AddForce(new Vector2(-Mathf.Sign(rb.velocity.x) * horizontalRetardation, 0));
        }
            
        if(Mathf.Abs(rb.velocity.x) < minRunSpeed)
        {
            animator.SetBool("moving", false);
        }
        else
        {
            animator.SetBool("moving", true);
            animator.SetFloat("movingSpeed", Mathf.Abs(rb.velocity.x) * animationFactor);
        }

        if(!facingRight)
        {
            transform.localScale = new Vector3(scale, scale, 1);
        }
        else
        {
            transform.localScale = new Vector3(-scale, scale, 1);
        }
        


        if (Input.GetKeyDown(jump) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            //rb.AddForce(new Vector2(0, jumpSpeed) * Time.deltaTime * 1000);
        }

    }

}
