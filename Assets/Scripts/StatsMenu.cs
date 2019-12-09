using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{
    public Text highScore;

    public Text totalCrashes;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore",0);
        totalCrashes.text = "TOTAL CRASHES: " + PlayerPrefs.GetInt("DeathCount",0);
    }

    public void ResetStats()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore",0);
        totalCrashes.text = "TOTAL CRASHES: " + PlayerPrefs.GetInt("DeathCount",0);
    }

}
