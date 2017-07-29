using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]


public class CharController : MonoBehaviour
{
    [SerializeField] [Range(0, 1)]
    private float stdspeed;

    [SerializeField]
    [Range(0, 1)]
    private float gravityUp;
    [SerializeField]
    [Range(0, 1)]
    private float gravityDw;

    private float speed;
    private bool isGrounded;
    private bool stunned;

    [SerializeField]
    [Range(0, 1)]
    private float timer;

    private float gravity;
    private Rigidbody2D rb;

    [Range(0, 1)]
    [SerializeField]
    private float jumpForce;

    private void Awake()
    {
        speed = stdspeed;
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
    }

    private void Update()
    {
        if (isGrounded)
        {
            rb.gravityScale = gravity;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.gravityScale = gravityUp;
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        if (!stunned)
        {
            Movement();
            if (!isGrounded)
            {
                if (rb.velocity.y <= 0)
                {
                    rb.gravityScale = gravityDw;
                }
            }
        }
        else
        {
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
                stunned = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GND")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GND")
        {
            isGrounded = true;
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
        Vector2 velocity = new Vector2(Vector2.right.x * speed * h * Time.fixedDeltaTime * 300, rb.velocity.y);

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

    public void Slow()
    {
        speed = stdspeed / 2;  
    }

    public void Stun()
    {
        stunned = true;
    }

    public void ResetSpeed()
    {
        speed = stdspeed;
    }
}