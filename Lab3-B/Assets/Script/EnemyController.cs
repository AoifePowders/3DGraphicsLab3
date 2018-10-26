using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    static bool goLeft = false;
    private int timer = 300;
    public GameObject enemyBullet;
    public Transform enemyShotSpawn;
    private AudioSource audio;
    private int enemyNo;
    public GameObject enemyBlock;

    //For Scoring 
    public int scoreValue;
    private GameController gameController;
    void Start()
    {
        enemyNo = 24;

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
        //Generates a random number between 1 and 4 and does this for each enemy so only some shoot at a time
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

        if (enemyNo == 0)
        {
            gameController.winGame();
        }

        if (gameController.livesLeft == 0)
        {
            enemyBlock.GetComponent<EnemyMover>().enabled = false;
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
            enemyNo -= 1;
        }

        if (other.tag == "Player")
        {
            enemyBlock.GetComponent<EnemyMover>().enabled = false;
            gameController.loseGame();   
        }


    }
}
