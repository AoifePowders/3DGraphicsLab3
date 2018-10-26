using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    GameObject varGameObject;

    public int startWait;

    //Text for score
    public GUIText score;
    private int scoreV;
  
    //Text for lives
    public GUIText lives;
    public int livesLeft;

    //Text for lose condition
    public GUIText lose;

    //Text for lose condition
    public GUIText win;

    //Text for restart
    public GUIText restartText;

    private bool restart;
    private bool gameOver;

    void Start ()
    {

       

        restart = false;
        gameOver = false;
        restartText.text = "";
        scoreV = 0;
        livesLeft = 3;
        UpdateScore();
        UpdateLives();
    }

    void Update()
    {
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }


    public void incrementScore(int newScore)
    {
        scoreV += newScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        score.text = "Score: " + scoreV;
        if(scoreV == 34)
        {
            winGame();
        }
    }


    public void decrementLives(int lifeLost)
    {
        livesLeft -= lifeLost;
        UpdateLives();

    }

    void UpdateLives()
    {
        lives.text = "Lives : " + livesLeft;
    }

    public void loseGame()
    {
        lose.text = "You Lose";
        gameOver = true;
        if (gameOver == true)
        {
            GameObject.Find("EnemyBlock").GetComponent<EnemyMover>().enabled = false;
            restartText.text = "Press 'R' to Restart";
            restart = true;
        }

     
    }

    public void winGame()
    {
        win.text = "You Win";
        gameOver = true;

        if (gameOver == true)
        {
            GameObject.Find("EnemyBlock").GetComponent<EnemyMover>().enabled = false;
            restartText.text = "Press 'R' to Restart";
            restart = true;
        }

        

    }

}
