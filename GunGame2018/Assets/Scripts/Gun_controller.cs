using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun_controller : MonoBehaviour {

    public GameObject prefabBullet;
    public float recoil;
    public float bulletsPerRound;
    private float bullets;
    public float minTimeBetweenBullets;
    private float timeSinceLastShot;
    private Hand_controller hand;

    //public Text bulletstext;

    // Use this for initialization
    void Start () {
        hand = GetComponentInParent<Hand_controller>();
        bullets = bulletsPerRound;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && bullets > 0 && timeSinceLastShot > minTimeBetweenBullets)
        {
            Vector3 rotation = hand.getShoulder().getRotation();
            prefabBullet.transform.eulerAngles = rotation - new Vector3(0, 0, -90);
            prefabBullet.transform.position = transform.position;
            prefabBullet.gameObject.layer = LayerMask.NameToLayer("Player_Bullets");
            Instantiate(prefabBullet);

            var recoilDir = Quaternion.AngleAxis(rotation.z, Vector3.forward) * Vector3.right;
            GameObject.Find("Player").GetComponent<Rigidbody2D>().AddForce(recoilDir * recoil);
            
            bullets--;
            writeBulletsOnUI();

            timeSinceLastShot = 0;
        }
        timeSinceLastShot += Time.deltaTime;
    }

    private void writeBulletsOnUI()
    {
        GameObject.Find("Bullets_count").GetComponent<Text>().text = "Bullets " + bullets;
    }

    public void reload()
    {
        bullets = bulletsPerRound;
        writeBulletsOnUI();
    }
}
