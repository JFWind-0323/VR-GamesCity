using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Blade : MonoBehaviour
{
   
    public float bladeForce = 1;
    public int score = 0;
    public float force=0;
    Vector3 position = Vector3.zero;
    Transform rightHandAnchor;
   public  GameObject Apple;
   public  GameObject Pear;
   public  GameObject Watermellon;

    [SerializeField] TMP_Text scoreText;
   

    public int Combo =0;
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Fruit"))
        {

            GetPosition();
        }
        if (other.gameObject.CompareTag("Bomb"))
        {

           BombExplode(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Fruit"))
        {
            CutFruit(other.gameObject);
        }
    }

    void GetPosition()
    {
        rightHandAnchor = GameObject.Find("RightHandAnchor").transform;
        position = rightHandAnchor.position;

    }







    void CutFruit(GameObject fruit)
    {
        rightHandAnchor = GameObject.Find("RightHandAnchor").transform;
        Vector3 newPosition = rightHandAnchor.position;

        Rigidbody rb = fruit.GetComponent<Rigidbody>();
        GameObject slicedFruit = Instantiate(GetSliced(fruit.GetComponent<FruitScore>().type), fruit.transform.position, fruit.transform.rotation);
        Transform[] childTransforms = slicedFruit.GetComponentsInChildren<Transform>();
        Vector3 direction = newPosition - position; 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        slicedFruit.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // 遍历子物体并调整它们的位置
        foreach (Transform childTransform in childTransforms)
      {
            
           childTransform.position = fruit.transform.position;
            Transform child1 = childTransforms[1]; // 假设第一个子物体
            Transform child2 = childTransforms[2]; // 假设第二个子物体
            
        }

        Rigidbody[] slices = slicedFruit.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody slice in slices)
        {
            slice.transform.parent = null;
            slice.velocity = fruit.GetComponent<Rigidbody>().velocity;
            slice.AddForceAtPosition(direction * force, gameObject.transform.position, ForceMode.Impulse);
          
            Destroy(slice.gameObject, 1f);
        }

        fruit.SetActive(false);
      
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
            Debug.Log("1");
            score += fruitScore;
            scoreText.text = "Score:" + score;
            scoreText.color = Color.blue;
        }
    }
    void BombExplode(GameObject bomb)
    {
        Combo = 0;
        bomb.SetActive(false);
        if (score > 0)
            score = score - 1;
        scoreText.text = "Score:" + score;
        scoreText.color = Color.red;
    }
    public GameObject  GetSliced(FruitType type)
    {
        switch (type)
        {
            case FruitType.Apple:
                return Apple;
            case FruitType.Banana:
                return Pear;
            case FruitType.Watermellon:
                return Watermellon;
            default:
                return Apple;

        }

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
