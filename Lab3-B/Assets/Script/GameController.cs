using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Text for score
    public GUIText score;
    private int scoreV;
    //

    //Text for lives
    public GUIText lives;
    private int livesLeft;

    //
    // Use this for initialization
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


}
