using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_pack_controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(GameObject.FindGameObjectWithTag("Player")))
        {
            other.GetComponent<Health_controller>().restoreHealth();

            Destroy(gameObject);
        }
    }
}
