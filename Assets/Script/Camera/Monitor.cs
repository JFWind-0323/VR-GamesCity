using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class Monitor : MonoBehaviourPun
{
    public int localScore;
    public bool flag;
    private void Start()
    {
        flag = true;
    }

    void Update()
    {
        if (PhotonNetwork.InRoom && photonView.IsMine && flag)
        {
            photonView.RPC("SyncScoreData", RpcTarget.Others, localScore);
            flag = false;
        }
    }
    [PunRPC]
    void SyncScoreData(int score)
    {
        
    }
}
