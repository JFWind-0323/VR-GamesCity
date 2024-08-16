using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] prefabs; // Ԥ����  

    public Transform spawnArea; // ָ����Collider��Χ  
    public Queue<GameObject> pooledObjects = new Queue<GameObject>(); // �����  
    private const int initialPoolSize = 100; // ��ʼ�ش�С  

    public void PaseOrStartGame(int GameType)
    {
        switch (GameType)
        {
            case 0:
                // ÿ1.5������һ��Ԥ����  
                InvokeRepeating("SpawnObject", 0f, 0.3f);
                break;
            case 1:
                CancelInvoke("SpawnObject");
                break;
        }
    }
    void Start()
    {
        // ��ʼ�������  
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(prefabs[Random.Range(0,prefabs.Length)]);
            obj.SetActive(false); // ��ʼʱ������  
            pooledObjects.Enqueue(obj);
        }
    }

    void SpawnObject()
    {
        if (pooledObjects.Count > 0)
        {
            GameObject obj = pooledObjects.Dequeue(); // �ӳ���ȡ��һ������  
            Debug.Log(pooledObjects.Count);

            obj.SetActive(true); // �������  
            obj.transform.position = GetRandomPositionInsideCollider(spawnArea); // �������λ��  
            pooledObjects.Enqueue(obj); // ������Żس�β���Ա��´�ʹ��
        }
        else
        {
            Debug.LogError("������ѿգ��޷������µĶ���");
        }
    }

    // ��ȡCollider�ڲ������λ��  
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