using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(fileName = "ScoreData", menuName = "ScriptableObject/������÷�����", order = 0)]
public class BalloonScore: ScriptableObject
{
    public float Balloonscore=0;
    
    public void ResetScore()
    {
       Balloonscore = 0;

    }
    public void GetScore()
    {
      Balloonscore ++;
    
    }


}
