using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Creates the boundary marks on the map 
public class Boundary
{
    public float xMin, xMax;
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

        //sets the rigidbodys pos to the current trasform
        rb.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);


    }

    void Update()
    {
        //Gets the input from the Left mouse button and then creates the bolt and changes it position
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            //plays the sound effect
            audio.Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Gets the mouse key input for the horizontal movement of the player
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        rb.velocity = movement * speed;


        // Boundary detection (clamp was causing errors) 
        if(transform.position.x < -45)
        {
            rb.position = new Vector3(boundary.xMin, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 45)
        {
            rb.position = new Vector3(boundary.xMax, transform.position.y, transform.position.z);
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBolt")
        {
            Destroy(other.gameObject);
            //Resets it position to the starting position
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            lives -= 1;
            gameController.decrementLives(damageDone);

            if (lives == -2)
            {
                die();
            }
        }

    }

    void die()
    {
        gameController.loseGame();
        Destroy(gameObject);
    }


}

