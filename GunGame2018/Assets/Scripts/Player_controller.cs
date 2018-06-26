using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour {


    private KeyCode right = KeyCode.D;
    private KeyCode left = KeyCode.A;
    private KeyCode jump = KeyCode.Space;

    private bool canJump = false;
    private Rigidbody2D rb;

    public float horizontalSpeed = 10f;
    public float jumpSpeed = 0.1f;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float x = 0;

        if (Input.GetKey(right))
        {
            x = horizontalSpeed;
        }
        if (Input.GetKey(left))
        {
            x =  -horizontalSpeed;
        }

        rb.velocity = new Vector2(x, rb.velocity.y);

        if (Input.GetKeyDown(jump) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            canJump = false;
            //rb.AddForce(new Vector2(0, jumpSpeed) * Time.deltaTime * 1000);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        canJump = true;
    }

}
