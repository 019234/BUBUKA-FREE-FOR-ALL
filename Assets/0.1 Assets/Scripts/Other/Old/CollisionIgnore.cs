using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnore : MonoBehaviour
{
    public GameObject[] targetsToIgnore;

    void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject target in targetsToIgnore)
        {
            if (collision.gameObject == target)
            {
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), true);
                break; // Stop checking once a match is found
            }
        }
    }
}