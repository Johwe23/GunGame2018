using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour {


    private KeyCode right = KeyCode.D;
    private KeyCode left = KeyCode.A;
    private KeyCode jump = KeyCode.Space;

    private Rigidbody2D rb;

    public float horizontalSpeed = 0.1f;
    public float jumpSpeed = 0.1f;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float x = transform.position.x;
        float y = transform.position.y;

        if (Input.GetKey(right))
        {
            x += horizontalSpeed;
        }
        if (Input.GetKey(left))
        {
            x -= horizontalSpeed;
        }

        transform.position = new Vector2(x, y);

        if (Input.GetKeyDown(jump))
        {
            rb.velocity = new Vector2(0, jumpSpeed);
            //rb.AddForce(new Vector2(0, jumpSpeed) * Time.deltaTime * 1000);
        }

    }

}
