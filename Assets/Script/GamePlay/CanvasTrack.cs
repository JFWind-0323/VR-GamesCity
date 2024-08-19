using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasTrack : MonoBehaviour
{
    public static CanvasTrack Instance;
    Transform player;

    [Header("与玩家的距离")]
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

        //第一个参数是需要看向的方向，第二个参数是需要保持平齐的方向
        Quaternion lookRotation = Quaternion.LookRotation(player.forward, Vector3.up);

        // 保持 X 和 Z 轴没有旋转，只旋转 Y 轴
        transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
    }
}
