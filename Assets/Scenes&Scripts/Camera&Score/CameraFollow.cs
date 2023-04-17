using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float yOffset = 2f;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
            FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, playerTransform.position.y + yOffset, transform.position.z);

        if (targetPosition.y > transform.position.y)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
