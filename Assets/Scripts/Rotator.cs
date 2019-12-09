using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float tumble = 5f;

    private Rigidbody rB;
    // Start is called before the first frame update
    void Start()
    {
        rB = gameObject.GetComponent<Rigidbody>();
        rB.angularVelocity = Random.insideUnitSphere * tumble;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
