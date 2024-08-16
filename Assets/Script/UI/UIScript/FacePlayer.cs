using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;  // 玩家（或摄像机）对象的Transform

    void Update()
    {
        // 使Canvas始终面向玩家
        transform.LookAt(player);
    }
}
