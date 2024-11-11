using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Đối tượng mà camera sẽ theo dõi
    public float smoothTime = 0.3f; // Thời gian mượt cho việc di chuyển camera
    public Vector2 minPosition; // Giới hạn tối thiểu của camera
    public Vector2 maxPosition; // Giới hạn tối đa của camera

    private Vector3 velocity = Vector3.zero; // Biến để lưu trữ vận tốc cho SmoothDamp

    void LateUpdate()
    {
        if (target != null)
        {
            
            Vector3 targetPosition = new Vector3(
                Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x), 
                Mathf.Clamp(target.position.y, minPosition.y, maxPosition.y), 
                transform.position.z); // giữ nguyên trục z của camera

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
