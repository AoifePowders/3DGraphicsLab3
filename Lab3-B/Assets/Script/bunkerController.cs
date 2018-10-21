using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunkerController : MonoBehaviour
{
    public GUIText bunkerText;
    private int health;
    public int damage;
    public GameObject Bolt;


	// Use this for initialization
	void Start ()
    {
        health = 10;
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void decrementHealth(int damage)
    {
        health -= damage;

    }

    void UpdateScore()
    {
        bunkerText.text =health.ToString();
    }

  

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bolt")
        {
            transform.localScale -= new Vector3(0.5f, 0.3f, 0);
            decrementHealth(damage);
            UpdateScore();
            Destroy(other.gameObject);
        }

        if(health == 0)
        {
            Destroy(gameObject);
            Destroy(bunkerText);
        }
    }
}
