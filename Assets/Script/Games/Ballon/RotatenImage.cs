using UnityEngine;

public class RotateImage : MonoBehaviour
{
    public float rotationSpeed = 50f; // 旋转速度

    void Update()
    {
        // 每帧旋转
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}