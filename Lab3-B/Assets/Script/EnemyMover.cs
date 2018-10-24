using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    static bool goLeft = false;
    // Update is called once per frame
    void FixedUpdate ()
    {
        if (goLeft)
        {
            transform.position = new Vector3(transform.position.x - (5 * Time.deltaTime), transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + (5 * Time.deltaTime), transform.position.y, transform.position.z);
        }


        if (transform.position.x >= 10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5f);
            goLeft = true;
        }
        if (transform.position.x <= -10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5f);
            goLeft = false;
        }
    }
}
