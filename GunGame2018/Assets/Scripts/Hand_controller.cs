using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_controller : MonoBehaviour {

    ShoulderMovement shoulder;

    // Use this for initialization
    void Start () {
        shoulder = GetComponentInParent<ShoulderMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public ShoulderMovement getShoulder()
    {

        return shoulder;
    }
}
