using UnityEngine;

public class RotateImage : MonoBehaviour
{
    public float rotationSpeed = 50f; // ��ת�ٶ�

    void Update()
    {
        // ÿ֡��ת
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}