using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 1f;

    SpriteRenderer rend;

    Rigidbody2D rb;

    public int jump;

    public float jumpPower;

    bool moving;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime, Space.World);
            rend.flipX = true;
            moving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime, Space.World);
            rend.flipX = false;
            moving = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jump > 0)
            {
                rb.AddForce(Vector2.up * jumpPower);
                jump--;
            }
            Debug.Log("'Space' key has been pressed");
        }
    }
}
