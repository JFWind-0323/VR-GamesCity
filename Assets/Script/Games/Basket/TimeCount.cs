using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public float timeCounter;
    [SerializeField] TMP_Text timeText;
    public GameObject basket1;
    public GameObject basket2;
    public GameObject basket3;
    Vector3 pos1;
    Vector3 pos2;
    Vector3 pos3;


    public float speed = 1;
   
    private void OnEnable()
    {
        timeCounter = 60f;
         pos1 = basket1.transform.position;
         pos2 = basket2.transform.position;
         pos3 = basket3.transform.position;

    }
    private void Update()
    {
        ShowUI();
        timeCounter -= Time.deltaTime;
        if (timeCounter < 0)
        {
            gameObject.SetActive(false);
            basket1.transform.position = pos1;
            basket2.transform.position = pos2;
            basket3.transform.position = pos3;

        }
        else
        {
            if (timeCounter < 30)
            {
               
                //每帧都给游戏物体一个新的坐标
                basket1.transform.position = new Vector3(basket1.transform.position.x+0.003f * Mathf.Sin(Time.time * speed), basket1.transform.position.y, basket1.transform.position.z);
                basket2.transform.position = new Vector3(basket2.transform.position.x + 0.003f * Mathf.Sin(Time.time * speed), basket2.transform.position.y, basket2.transform.position.z);
                basket3.transform.position = new Vector3(basket3.transform.position.x + 0.003f * Mathf.Sin(Time.time * speed), basket3.transform.position.y, basket3.transform.position.z);
            }
        }
    }
    public void ShowUI()
    {
        timeText.text= "Time:"+timeCounter;

    }
}
