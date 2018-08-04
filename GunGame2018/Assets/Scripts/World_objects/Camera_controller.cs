using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour {

    [SerializeField]
    public GameObject player;
    public float yOffset;
    public float borderOffset;

    private float startX, endX; 


	// Use this for initialization
	void Start () {
        startX = GameObject.Find("Level start").transform.position.x + borderOffset;
        endX = GameObject.Find("Level finish").transform.position.x - borderOffset;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, -10);
        if (transform.position.x < startX)
            transform.position = new Vector3(startX, transform.position.y, transform.position.z);
        else if (transform.position.x > endX)
            transform.position = new Vector3(endX, transform.position.y, transform.position.z);
    }
}
