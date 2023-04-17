using UnityEngine;

public class FloatingCloud : MonoBehaviour
{
    public float minTransparency = 0.5f;
    public float maxTransparency = 1f;

    private float speed;
    private int direction;

    public void Initialize(int sortingOrder, float speed)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sortingOrder = sortingOrder;

        this.speed = speed;

        float transparency = Random.Range(minTransparency, maxTransparency);
        Color color = spriteRenderer.color;
        spriteRenderer.color = new Color(color.r, color.g, color.b, transparency);

        bool flipX = (Random.value > 0.5f);
        spriteRenderer.flipX = flipX;
    }

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
    }
}
