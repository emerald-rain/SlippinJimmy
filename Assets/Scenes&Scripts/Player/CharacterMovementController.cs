using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public GameObject character;
    public float characterSpeed = 5.0f;
    public float smoothing = 5.0f;

    private float currentHorizontalInput;

    void Update()
    {
        float targetHorizontalInput = Input.GetAxis("Horizontal");

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < Screen.width / 2)
            {
                targetHorizontalInput = -1;
            }
            else if (touch.position.x > Screen.width / 2)
            {
                targetHorizontalInput = 1;
            }
        }

        currentHorizontalInput = Mathf.Lerp(currentHorizontalInput, targetHorizontalInput, smoothing * Time.deltaTime);
        character.transform.position += new Vector3(currentHorizontalInput * characterSpeed * Time.deltaTime, 0, 0);

        if (currentHorizontalInput > 0)
        {
            character.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (currentHorizontalInput < 0)
        {
            character.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
