﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoulderMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    //Public Vars
    public Camera camera;

    //Private Vars
    private Vector3 mousePosition;
    private Vector3 direction;

    void FixedUpdate()
    {


        //Grab the current mouse position on the screen
        mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - camera.transform.position.z));

        //Rotates toward the mouse
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg - 180);


    }//End Fire3 If case


// Update is called once per frame
       void Update () {
	   }

    public Vector3 getRotation()
    {
        return transform.eulerAngles;
    }
}

