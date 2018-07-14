using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Coin_behavior : MonoBehaviour {

    private int coins = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(GameObject.FindGameObjectWithTag("Player")))
        {
            GameObject.Find("CoinManager").GetComponent<Coin_manager>().collectCoin();
            Destroy(gameObject);
        }
    }
}
