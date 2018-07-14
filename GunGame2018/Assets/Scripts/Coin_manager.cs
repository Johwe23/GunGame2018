using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_manager : MonoBehaviour {


    private int coins;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void collectCoin()
    {
        coins++;
        GameObject.Find("Coins").GetComponent<Text>().text = "Coins: " + coins;
    }
}
