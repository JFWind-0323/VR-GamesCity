using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Blade : MonoBehaviour
{
   
    public float bladeForce = 1;
    public int score = 0;
    public float force=0;
    Vector3 position = Vector3.zero;
    Transform rightHandAnchor;
    public  GameObject Apple;
    public  GameObject Pear;
    public GameObject Icosphere;
    public  GameObject Coconut;
    public GameObject Lemon;
    public GameObject Houlonggou;
    public GameObject Orange;
        

    [SerializeField] TMP_Text scoreText;
   

    public int Combo =0;
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Fruit"))
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
            SoundManager.Instance.PlaySoundEffect(SoundsGlobal.CutFruit, 0.5f);
            SoundManager.Instance.PlaySoundEffect(SoundsGlobal.Juice, 1f);
           
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
            Transform child1 = childTransforms[0]; // 假设第一个子物体
            Transform child2 = childTransforms[1]; // 假设第二个子物体
            
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
            case FruitType.Pear:
                return Pear;
            case FruitType.Icosphere:
                return Icosphere;
            case FruitType.Coconut:
                return Coconut;
            case FruitType.Lemon:
                return Lemon;
    
            case FruitType.Houlonggou:
                return Houlonggou;
            case FruitType.Orange:
                return Orange;
            default:
                return null;

        }

    }
   public int GetScoreForFruit(FruitType type)
    {
        switch (type)
        {
        case FruitType.Apple:
            return 2;
        case FruitType.Coconut:
            return 1;
        case FruitType.Lemon:
            return 3;
        case FruitType.Icosphere:
            return 1;
        case FruitType.Pear:
            return 2;
        case FruitType.Houlonggou:
            return 3;
        case FruitType.Orange:
            return 5;
        default:
          return 0;

        }
    }
}
