using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_die : MonoBehaviour {

    public float deathTime;
    private Animator animator;

    private bool dead = false;

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void die()
    {
        animator.SetBool("dead", true);
        Destroy(gameObject, deathTime);
        dead = true;
        GetComponent<Enemy_utils>().die();

    }

    public bool isDead()
    {
        return dead;
    }
}
