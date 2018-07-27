using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_gun : MonoBehaviour {

    public GameObject bullet;
    public float minTimeBetweenBullets;
    private float timeSinceShot;
    private Vector3 rotation;

    private bool idle = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(timeSinceShot > minTimeBetweenBullets && !idle)
        {
            bullet.transform.position = transform.position;
            bullet.transform.eulerAngles = rotation - new Vector3(0, 0, -90);
            bullet.gameObject.layer = LayerMask.NameToLayer("Enemy_Bullets");
            Instantiate(bullet);
            //activeBullet.transform.parent = transform;

            timeSinceShot = 0;
        }

        timeSinceShot += Time.deltaTime;
	}

    public void setRotation(Vector3 rot)
    {
        this.rotation = rot;
    }

    public void setIdle(bool idle)
    {
        this.idle = idle;
    }

    void OnApplicationQuit()
    {
        bullet.transform.position = new Vector3(0, 0, 0);
        bullet.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }


}
