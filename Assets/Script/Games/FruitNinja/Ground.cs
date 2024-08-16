using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public void OnColliderEnter(Collider fruit)
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
