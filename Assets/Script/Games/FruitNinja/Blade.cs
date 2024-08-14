using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Blade : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    public float bladeForce = 1;
    public int score = 0;
    [SerializeField] TMP_Text scoreText;

    public int Combo =0;
    private void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.CompareTag("Fruit"))
        {

            CutFruit(other.gameObject);
        }
        if (other.gameObject.CompareTag("Bomb"))
        {

           BombExplode(other.gameObject);
        }
    }
    void CutFruit(GameObject fruit)
    {
        Rigidbody rb = fruit.GetComponent<Rigidbody>();
        GameObject slicedFruit = Instantiate(slicedFruitPrefab, fruit.transform.position, fruit.transform.rotation);
        slicedFruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * bladeForce, ForceMode.Impulse);

        if(fruit!=null)
        Destroy(fruit);
        Destroy(slicedFruit, 0.2f);
        Combo++;

      int fruitScore=  GetScoreForFruit(fruit.GetComponent<FruitScore>().type);
        if (Combo > 10)
        {
            score += fruitScore;
            score += Combo ;
            scoreText.text = "Combo!" + Combo+"Score:"+score;
            scoreText.color = Color.yellow;
        }
        else
        {
            score += fruitScore;
            scoreText.text = "Score:" + score;
            scoreText.color = Color.black;
        }
    }
    void BombExplode(GameObject bomb)
    {
        Combo = 0;
        Destroy(bomb);
        if (score > 0)
            score = score - 5;
        scoreText.text = "Score:" + score;
        scoreText.color = Color.red;
    }
   public int GetScoreForFruit(FruitType type)
    {
        switch (type)
        {
        case FruitType.Apple:
        return 2;
            case FruitType.Banana:
            return 3;
        case FruitType.Watermellon:
            return 1;
            default:
                return 0;

        }
    }
}
