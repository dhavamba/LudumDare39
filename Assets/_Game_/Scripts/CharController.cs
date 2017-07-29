using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]


public class CharController : MonoBehaviour
{
    [Range(0, 3)]
    [SerializeField]
    private float stdspeed;
    private float speed;
    private bool isGrounded;

    private Rigidbody2D rb;

    [Range(0, 1)]
    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private bool duble;

    private void Start()
    {
        speed = stdspeed;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (!isGrounded)
        {
           
            if (Input.GetKeyDown(KeyCode.UpArrow) && duble)
            {
                duble = false;
                dubleJump();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GND")
        {
            isGrounded = true;
            duble = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GND")
        {
            isGrounded = false;
        }
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(Vector2.right.x * speed  * h, rb.velocity.y);

        rb.velocity = velocity;

        if (velocity.x < 0)
        {
            rb.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rb.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce * 1000);
    }

    void dubleJump()
    {
        duble = false;
        Jump();
    }
    

    public void Slow()
    {
        speed = stdspeed / 2;  
    }

    public void Stun()
    {
        //Stun effect
    }

    public void ResetSpeed()
    {
        speed = stdspeed;

    }
}

