using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_controller : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float damage;

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

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.GetComponent<Health_controller>() != null)
        {
            other.gameObject.GetComponent<Health_controller>().hurt(damage, this);
        }
        Destroy(gameObject);
    }

}
