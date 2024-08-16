using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] prefabs; // 预制体  

    public Transform spawnArea; // 指定的Collider范围  
    public Queue<GameObject> pooledObjects = new Queue<GameObject>(); // 对象池  
    private const int initialPoolSize = 100; // 初始池大小  

    public void PaseOrStartGame(int GameType)
    {
        switch (GameType)
        {
            case 0:
                // 每1.5秒生成一个预制体  
                InvokeRepeating("SpawnObject", 0f, 0.3f);
                break;
            case 1:
                CancelInvoke("SpawnObject");
                break;
        }
    }
    void Start()
    {
        // 初始化对象池  
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(prefabs[Random.Range(0,prefabs.Length)]);
            obj.SetActive(false); // 初始时不激活  
            pooledObjects.Enqueue(obj);
        }
    }

    void SpawnObject()
    {
        if (pooledObjects.Count > 0)
        {
            GameObject obj = pooledObjects.Dequeue(); // 从池中取出一个对象  
            Debug.Log(pooledObjects.Count);

            obj.SetActive(true); // 激活对象  
            obj.transform.position = GetRandomPositionInsideCollider(spawnArea); // 设置随机位置  
            pooledObjects.Enqueue(obj); // 将对象放回池尾，以便下次使用
        }
        else
        {
            Debug.LogError("对象池已空，无法生成新的对象！");
        }
    }

    // 获取Collider内部的随机位置  
    Vector3 GetRandomPositionInsideCollider(Transform area)
    {
        var bounds = area.GetComponent<Collider>().bounds;
        Vector3 randomPointInBounds = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
        return randomPointInBounds;
    }
 
}