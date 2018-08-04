using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health_controller : MonoBehaviour {

    public float health;
    private float currentHealth;

    public ParticleSystem deathParticle;
    public Slider healthBar;

	// Use this for initialization
	void Start () {
        currentHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.transform.localScale = new Vector3(Mathf.Sign(transform.localScale.x), healthBar.transform.localScale.y, 1);
	}

    public void hurt (float damage, GameObject cause)
    {
        
        currentHealth -= damage;
        updateHealthBar();

        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<Enemy_die>().die();
                die();
            }
            else if(gameObject.tag == "Player")
            {
                gameObject.GetComponent<Animator>().SetBool("dead", true);
                Destroy(gameObject, 3);
                Wait();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        deathParticle.transform.position = cause.transform.position;
        deathParticle.transform.eulerAngles = new Vector3(0, -42, cause.transform.eulerAngles.z - 180);
        Instantiate(deathParticle);

        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
    }

    private void updateHealthBar()
    {
        healthBar.value = currentHealth / health;
    }

    public void die()
    {
        
    }

    public void restoreHealth()
    {
        currentHealth = health;
        updateHealthBar();
    }

    void OnApplicationQuit()
    {
        deathParticle.transform.position = new Vector3(0, 0, 0);
        deathParticle.transform.rotation = new Quaternion(0, -42, 0, 1);
    }


}
