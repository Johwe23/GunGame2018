using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_controller : MonoBehaviour {

    public float health;
    private float currentHealth;

    public ParticleSystem deathParticle;

	// Use this for initialization
	void Start () {
        currentHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hurt (float damage, Bullet_controller bullet)
    {
        
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<Enemy_die>().die();
            }
        }

        deathParticle.transform.position = bullet.transform.position;
        deathParticle.transform.eulerAngles = new Vector3(0, -42, bullet.transform.eulerAngles.z - 180);
        Instantiate(deathParticle);
    }

    void OnApplicationQuit()
    {
        deathParticle.transform.position = new Vector3(0, 0, 0);
        deathParticle.transform.rotation = new Quaternion(0, -42, 0, 1);
    }


}
