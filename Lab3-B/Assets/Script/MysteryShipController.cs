using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryShipController : MonoBehaviour
{
    int speed = 10;
    int timer = 0;

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
}
