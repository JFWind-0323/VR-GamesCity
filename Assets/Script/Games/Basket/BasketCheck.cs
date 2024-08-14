using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasketCheck : MonoBehaviour
{
    public BasketType basketType;
    [SerializeField] TMP_Text scoreText;
    public int score = 0;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BasketBall"))
        {
            int count = GetScoreForBasket();
            score += count;
            scoreText.text = "Score" + score;
        }
    }
    public int GetScoreForBasket()
    {
        switch (basketType)
        {
            case BasketType.oneScore:
                return 1;
            case BasketType.twoScore:
                return 2;
            case BasketType.threeScore:
                return 3;
            default:
                return 0;

        }
    }
}
