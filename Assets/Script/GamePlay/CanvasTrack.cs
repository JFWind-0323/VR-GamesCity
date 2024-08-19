using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasTrack : MonoBehaviour
{
    public static CanvasTrack Instance;
    Transform player;

    [Header("����ҵľ���")]
    [Range(0.5f, 1.5f)] public float distance = 1;

    private void Awake()
    {
        Instance = this;
        player = GameObject.Find("PlayerController").GetComponent<Transform>();
    }
    public void Track()
    {
        transform.position = player.position + player.forward * distance - new Vector3(0, player.position.y, 0);
        transform.localPosition += new Vector3(0, 0.5f, 0);

        //��һ����������Ҫ����ķ��򣬵ڶ�����������Ҫ����ƽ��ķ���
        Quaternion lookRotation = Quaternion.LookRotation(player.forward, Vector3.up);

        // ���� X �� Z ��û����ת��ֻ��ת Y ��
        transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
    }
}
