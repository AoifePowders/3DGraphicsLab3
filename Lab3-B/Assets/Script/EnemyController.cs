using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rigidBody;
    static bool goLeft = false;

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
