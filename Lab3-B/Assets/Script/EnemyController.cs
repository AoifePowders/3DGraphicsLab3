using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rigidBody;
    static bool goLeft = false;
    private int timer = 300;


    void Update()
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
        if(timer < 2)
        {
            int randomNumber = Random.Range(0, 4);
            int num = randomNumber;

            if(num == 2)
            {
                //fire
            }
            timer = 300;
        }

        if(transform.position.x >= 10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            goLeft = true;
        }
        if(transform.position.x <= -10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            goLeft = false;
        }
    }

}
