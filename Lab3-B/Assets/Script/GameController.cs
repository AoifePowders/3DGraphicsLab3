using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Text
    public GUIText score;
    private int scoreV;
    //

    // Use this for initialization
    void Start ()
    {
        scoreV = 0;
        UpdateScore();
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


}
