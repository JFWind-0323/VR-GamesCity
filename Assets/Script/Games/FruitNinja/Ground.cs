using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public void OnTriggerEnter(Collider fruit)
    {

        if (fruit.gameObject.CompareTag("Fruit")&&fruit.gameObject.CompareTag("Half"))
        {

            fruit.gameObject.SetActive(false);
        }
        if (fruit.gameObject.CompareTag("Bomb"))
        {

            fruit.gameObject.SetActive(false);
        }
    }
}
