using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BalloonShowScore : MonoBehaviour
{  
    [SerializeField] TMP_Text scoreText;
    public BalloonScore balloonScore;
    
   public  float score = 0;
    public void Update()
    {
        ShowScore();
    }
    public void ShowScore()
    {
        score = balloonScore.Balloonscore;
        scoreText.text = "Score:" + score;

    }
}
