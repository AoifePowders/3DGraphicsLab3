﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    private AudioSource audio;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public Boundary boundary;

    private float nextFire;

    public int lives;



    private GameController gameController;
    int damageDone;

    // Use this for initialization
    void Start ()
    {

        damageDone = 1;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot Find Game Controller Script");
        }

        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();

        rb.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);


    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audio.Play();
        }

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0, 0);



        rb.velocity = movement * speed;

        //rb.position = new Vector3
        //    (
        //        Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
        //        0.0f      
        //    );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBolt")
        {
                    Instantiate(gameObject, rb.transform.position = new Vector3(0,0, z: -36), rb.transform.rotation);
                    lives -= 1;
                    gameController.decrementLives(damageDone);
                    if (lives == 0)
                    {
                      Destroy(other.gameObject);
                      Destroy(gameObject);     
                    }
        }

    }



}

