using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_and_gun_controller : MonoBehaviour {

    ShoulderMovement shoulder;
    public GameObject prefabBullet;

	// Use this for initialization
	void Start () {
        shoulder = GetComponentInParent<ShoulderMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rotation = shoulder.getRotation();
            prefabBullet.transform.eulerAngles = rotation - new Vector3(0, 0, -90);
            prefabBullet.transform.position = transform.position;
            Instantiate(prefabBullet);
        }
	}
}
