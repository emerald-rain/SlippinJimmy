using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBounce : MonoBehaviour
{
    private const float BounceForce = 1700f;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * BounceForce);
        }
    }
}
