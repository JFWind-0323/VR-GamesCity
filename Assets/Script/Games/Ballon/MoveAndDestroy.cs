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
        // 移动预制体  
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        // 检查预制体是否已经移动了足够的距离，如果是，则销毁它  
        float distanceMoved = Vector3.Distance(startPosition, transform.position);
        if (distanceMoved >= destroyDistance)
        {
            
            ObjectPool.pooledObjects.Enqueue(gameObject);
            gameObject.SetActive(false);
        }
    }
}