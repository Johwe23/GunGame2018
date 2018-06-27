﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_controller : MonoBehaviour {

    public float speed;
    public float lifeTime;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
