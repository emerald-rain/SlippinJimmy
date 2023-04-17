using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnCollision : MonoBehaviour
{
    private const float JUMP_FORCE = 1000f;

    private void Start()
    {   
    }

    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * JUMP_FORCE);
        }
    }
}
