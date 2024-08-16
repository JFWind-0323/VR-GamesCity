using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;


public class BasketShowScore : MonoBehaviour
{
    public int score = 0;
    [SerializeField] TMP_Text scoreText;
    public void GetAndShowScore(int count)
    {

        score += count;
        scoreText.text = "Score:" + score;
    }
}
