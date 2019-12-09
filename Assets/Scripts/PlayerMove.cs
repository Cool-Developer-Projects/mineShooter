using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float minX, maxX, maxZ, minZ;
}

public class PlayerMove : MonoBehaviour
{
    public Boundary boundary;
    public float speed = 10f;

    private Rigidbody rB;

    //what we are shooting
    public GameObject shot;

    //from where are we shooting;
    public Transform shotSpawn;

    public float nextFire = 0f;

    public float fireRate = 0.25f;

    public float tilt = 4f;

    private int shotsFired;

    // Start is called before the first frame update
    void Start()
    {
        shotsFired = PlayerPrefs.GetInt("ShotsFired", 0);
        rB = gameObject.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rB.velocity = movement * speed;

        //prevent player from moving outside the screen
        //Using Mathf.Clamp to achieve;
        rB.position = new Vector3
        (
            Mathf.Clamp(rB.position.x, boundary.minX, boundary.maxX),
            0f,
            Mathf.Clamp(rB.position.z, boundary.minZ, boundary.maxZ)
        );

        //tilting
        rB.rotation = Quaternion.Euler(0f, 0f, rB.velocity.x * -tilt);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.Space)) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, Quaternion.identity /*shotSpawn.rotation*/);
            rB.GetComponent<AudioSource>().Play();
            shotsFired++;
            PlayerPrefs.SetInt("ShotsFired", shotsFired);
        }
    }
}
