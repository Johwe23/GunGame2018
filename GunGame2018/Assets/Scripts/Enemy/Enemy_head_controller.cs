using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_head_controller : MonoBehaviour {

    private Vector3 lookDirection;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

        lookDirection = Utils.getComponentInGrandParent<Enemy_shooter>(gameObject).getDirection();

        if (lookDirection.z > 220 && lookDirection.z < 270)
        {
            lookDirection = new Vector3(0, 0, 220);
        }
        else if (lookDirection.z < 320 && lookDirection.z >= 270)
        {
            lookDirection = new Vector3(0, 0, 320);
        }
        transform.eulerAngles = lookDirection + new Vector3(0, 0, 90 + -Mathf.Sign(transform.lossyScale.x) * 90);

        //Debug.Log(lookDirection);
    }
}
