using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCollision : MonoBehaviour {

    void onTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
