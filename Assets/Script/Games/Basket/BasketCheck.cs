using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasketCheck : MonoBehaviour
{
    public BasketType basketType;
    public BasketShowScore showScore;
    
    public int score = 0;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Basketball"))
        {
            SoundManager.Instance.PlaySoundEffect(SoundsGlobal.BasketHollow, 1f);
            int count = GetScoreForBasket();
            showScore.GetAndShowScore(count);
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
