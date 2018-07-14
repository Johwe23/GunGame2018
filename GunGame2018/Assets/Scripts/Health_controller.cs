﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_controller : MonoBehaviour {

    public float health;
    private float currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hurt (float damage)
    {
        
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<Enemy_die>().die();
            }
        }

        
    }
}