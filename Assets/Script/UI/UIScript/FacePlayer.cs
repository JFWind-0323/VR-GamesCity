using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;  // ��ң���������������Transform

    void Update()
    {
        // ʹCanvasʼ���������
        transform.LookAt(player);
    }
}
