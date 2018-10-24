using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
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

    void Start ()
    {
        scoreV = 0;
        livesLeft = 3;
        UpdateScore();
        UpdateLives();
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
    }

    public void winGame()
    {
        win.text = "You Win";
    }

}
