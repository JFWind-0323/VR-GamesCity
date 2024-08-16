using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public void OnCollisionEnter(Collision fruit)
    {

        if (fruit.gameObject.CompareTag("Fruit"))
        {

            fruit.gameObject.SetActive(false);
        }
        if (fruit.gameObject.CompareTag("Bomb"))
        {

            fruit.gameObject.SetActive(false);
        }
    }
}
