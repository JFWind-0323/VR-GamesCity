using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    public Vector3 direction = Vector3.forward; 
    public float speed = 0.01f;
    public float destroyDistance = 10f;

    private Vector3 startPosition;
    private ObjectPool ObjectPool;

    private void Awake()
    {
        ObjectPool = GameObject.FindObjectOfType<ObjectPool>();
    }
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // �ƶ�Ԥ����  
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        // ���Ԥ�����Ƿ��Ѿ��ƶ����㹻�ľ��룬����ǣ���������  
        float distanceMoved = Vector3.Distance(startPosition, transform.position);
        if (distanceMoved >= destroyDistance)
        {
            
            ObjectPool.pooledObjects.Enqueue(gameObject);
            gameObject.SetActive(false);
        }
    }
}