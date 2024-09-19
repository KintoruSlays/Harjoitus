using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 1f;

    public float jumpForce = 2f;

    SpriteRenderer rend;

    Rigidbody2D rb;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("moving", false);
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime, Space.World);
            rend.flipX = true;
            anim.SetBool("moving", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime, Space.World);
            rend.flipX = false;
            anim.SetBool("moving", true);
        }

        bool grounded = false;
        LayerMask layerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, layerMask);
        Debug.DrawRay(transform.position, Vector2.down * 0.7f, Color.red);
        if(hit)
        {
            grounded = true;
            Debug.Log("Ground found");
        }
        anim.SetBool("grounded", grounded);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
