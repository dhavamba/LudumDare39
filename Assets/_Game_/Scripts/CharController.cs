using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]


public class CharController : MonoBehaviour
{
    [SerializeField] [Range(0, 1)]
    private float stdspeed;

    [SerializeField] [Range(0, 1)]
    private float gravityUp;
    [SerializeField] [Range(0, 1)]
    private float gravityDw;
    [SerializeField] [Range(0, 1)]
    private float timeStunned;

    private float speed;
    private bool isGrounded;
    private bool stunned;

    private float timer;

    private float gravity;
    private Rigidbody2D rb;

    [Range(0, 1)] [SerializeField]
    private float jumpForce;

    private void Awake()
    {
        speed = stdspeed;
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
        timer = timeStunned * 10;
    }

    private bool GetInputJump()
    {
        return InputComand.Instance<InputComand>().Jump();
    }

    private void Update()
    {
        if (isGrounded)
        {
            rb.gravityScale = gravity;
            //if (GetInputJump())
            if (Input.GetAxis("Vertical") > 0)
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
            rb.velocity = Vector2.zero;
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                stunned = false;
                timer = timeStunned * 10;
                
            }
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

    private float GetInputMovement()
    {
        //return InputComand.Instance<InputComand>().Movement();
        return Input.GetAxis("Horizontal");
    }

    void Movement()
    {
        float input = GetInputMovement();
        Vector2 velocity = new Vector2(Vector2.right.x * speed * input * Time.fixedDeltaTime * 300, rb.velocity.y);

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
        if(!stunned)
            rb.AddForce(Vector2.up * jumpForce * 1000);
    }

    public void Slow()
    {
        speed = stdspeed / 2;  
    }

    public void Stun()
    {
        transform.Translate(-1f, 0, 0);
        stunned = true;
    }

    public void ResetSpeed()
    {
        speed = stdspeed;
    }
}