using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothness = 1f;

    private Vector3 offset;
    private float maxYPosition;

    void Start()
    {
        offset = transform.position - player.position;
        maxYPosition = transform.position.y;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        targetPosition.x = transform.position.x;

        targetPosition.y = Mathf.Max(targetPosition.y, maxYPosition);

        maxYPosition = Mathf.Max(maxYPosition, transform.position.y);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.fixedDeltaTime);
    }
}
