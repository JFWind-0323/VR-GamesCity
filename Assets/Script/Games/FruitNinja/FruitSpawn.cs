using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{ public float maxForce = 3f;
    public float minForce = 1f;
    private ObjectPool ObjectPool;
    
    
    private void Awake()
    {
        ObjectPool = GameObject.FindObjectOfType<ObjectPool>();
    }
    void Start()
    {
        float randomX = Random.Range(-30f, 30f);
        float randomZ = Random.Range(-30f, 30f);

        // 创建一个新的 Vector3 来表示随机角度
        Vector3 randomTorque = new Vector3(randomX,180f, randomZ).normalized;

        float force = Random.Range(minForce, maxForce);
        gameObject.GetComponent<Rigidbody>().AddForce(randomTorque * force,ForceMode.Impulse);

    }

}
