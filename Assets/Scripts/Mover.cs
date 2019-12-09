using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody rB;

    public float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        rB = gameObject.GetComponent<Rigidbody>();

        //move bolt forward upon entering the game scene.
        rB.velocity = transform.forward * speed;
    }
}
