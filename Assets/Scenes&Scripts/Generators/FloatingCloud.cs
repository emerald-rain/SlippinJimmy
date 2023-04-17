using UnityEngine;

public class FloatingCloud : MonoBehaviour
{

    private float speed;
    private int direction;

    public void Initialize(int sortingOrder, float speed)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sortingOrder = sortingOrder;

        this.speed = speed;

        bool flipX = (Random.value > 0.5f);
        spriteRenderer.flipX = flipX;
    }

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
    }
}
