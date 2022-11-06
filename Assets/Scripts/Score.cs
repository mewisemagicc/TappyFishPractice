using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    int score;
    Text scoreText;
    int highScore;

    public Text panelScore;
    public Text PanelHightScore;
    public GameObject newBest;
    


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highScore");
        PanelHightScore.text = highScore.ToString();
    }
    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        if(score > highScore)
        {
            highScore = score;
            PanelHightScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highScore", highScore);
            newBest.SetActive(true);
        }
    }
    public int GetScore()
    {
        return score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
