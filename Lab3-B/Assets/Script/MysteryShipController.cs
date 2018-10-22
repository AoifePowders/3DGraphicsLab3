using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryShipController : MonoBehaviour
{
    int speed = 10;
    int timer = 0;

    public int scoreValue;
    private GameController gameController;


    void Start()
    {
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
    // Update is called once per frame
    void FixedUpdate()
    {
        timer++;
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);
        if (transform.position.x <= -150)
        {
            speed = Random.Range(-10,-15);
        }

        if (transform.position.x >= 150)
        {
            speed = Random.Range(10, 15);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bolt")
        {
            gameController.incrementScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
