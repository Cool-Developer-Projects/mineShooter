using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;

    public GameObject playerExplosion;

    public GameObject barrierExplosion;

    public int scoreValue = 10;

    private GameController gameController;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        GameObject gameControllerObj = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObj != null)
        {
            gameController = gameControllerObj.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' object");
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver();
        }

        if (other.CompareTag("Barrier"))
        {
            Instantiate(barrierExplosion, transform.position, transform.rotation);
            gameController.GameOver();
        }

        //only add score if hit by laser bolt
        if (other.CompareTag("Bolt"))
        {
            gameController.AddScore(scoreValue);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
