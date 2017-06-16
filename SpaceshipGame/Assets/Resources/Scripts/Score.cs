using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private static Score instance;
    public static Score Instance { get { return instance; } }

    public int score;
    public Text scoreText;
    public Text highScoreText;

    public int highScore;
	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        highScoreText = GameObject.Find("HighScore").GetComponent<Text>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            //We had a previopus session ( Ja jogou antes )
            highScore = PlayerPrefs.GetInt("HighScore");
        }

        else
            Save();
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "HighScore: " + highScore;

        if(score > highScore)
        {
            highScore = score;
            Save();
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }
}