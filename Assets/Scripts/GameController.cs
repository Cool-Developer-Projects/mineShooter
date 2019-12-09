using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;

    public Vector3 spawnValues;

    public int hazardCount = 10;

    public float spawnWait = 0.5f;

    //pause before begining to spawn waves
    public float startWait = 1f;

    public float waveWait = 4f;

    public Text scoreText;

    public Text gameOverText;

    public Text restartText;

    public Text deathCountText;

    // public Text timeText;

    public bool gameOver;
    public bool restart;
    private int score;

    private int deathCount;

    private int overAllDeaths;

    // private float time;

    public GameObject playerObj;

    public GameObject barrierObj;


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameOverText.text = "";
        restartText.text = "";
        deathCount = PlayerPrefs.GetInt("Deaths",0);
        deathCountText.text = "C:" + deathCount;
        score = 0;
        overAllDeaths = PlayerPrefs.GetInt("DeathCount",0);
        // timeText.text = "T:0";

        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        // time += Time.time;
        // timeText.text = "T:" + time.ToString();
    }


    //Coroutine, wait before next spawn
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            //spawn asteroids
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                //instantiate hazads
                Instantiate(hazard, spawnPosition, spawnRotation);
                //wait before spawning next asteroid
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' to Restart.";
                restart = true;
                // playerObj.SetActive(true);
                break;
            }
        }

    }

    //called when asteroid is destroyed
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore",score);
        }
        scoreText.text = "S:" + score;
    }

    public void GameOver()
    {
        playerObj.SetActive(false);
        barrierObj.SetActive(false);
        gameOverText.text = "GAME OVER!";
        gameOver = true;
        deathCount++;
        int allDeaths = deathCount + overAllDeaths;
        PlayerPrefs.SetInt("Deaths", deathCount);
        PlayerPrefs.SetInt("DeathCount", allDeaths);
        deathCountText.text = "C:" + PlayerPrefs.GetInt("Deaths");
    }
}
