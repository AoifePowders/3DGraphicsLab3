﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    static bool goLeft = false;
    private int timer = 300;
    public GameObject enemyBullet;
    public Transform enemyShotSpawn;
    private AudioSource audio;


    //For Scoring 
    public int scoreValue;
    private GameController gameController;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot Find Game Controller Script");
        }
    }

    void FixedUpdate()
    {
        if (goLeft)
        {
            transform.position = new Vector3(transform.position.x - (5 * Time.deltaTime), transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + (5 * Time.deltaTime), transform.position.y, transform.position.z);
        }

        timer -= 1;
        if (timer < 2)
        {
            int randomNumber = Random.Range(0, 4);
            int num = randomNumber;

            if (num == 2)
            {
                Instantiate(enemyBullet, enemyShotSpawn.position, enemyShotSpawn.rotation);
            }
            timer = 300;
        }

        if (transform.position.x >= 45)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
            goLeft = true;
        }
        if (transform.position.x <=  -45)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
            goLeft = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bolt")
        {
            audio.Play();
            gameController.incrementScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
       
    }

 

}
