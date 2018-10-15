using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class EnemyMover : MonoBehaviour {

    private Rigidbody rigidBody;
    public float speed;
    public Boundary boundary;

	// Use this for initialization
	void FixedUpdate () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.right * -speed;
        if(rigidBody.position.x > boundary.xMax)
        {
            rigidBody.velocity = transform.right * speed;
        }
        else if (rigidBody.position.x < boundary.xMin)
        {
            rigidBody.velocity = transform.right * -speed;
        }
    }
}
