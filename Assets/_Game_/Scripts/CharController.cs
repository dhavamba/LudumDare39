using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]


public class CharController : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField]
    private float speed;
    private float stdspeed;
    private bool isGrounded;

    private Rigidbody2D rb;

    [Range(0, 1)]
    [SerializeField]
    private float jumpForce;

    [Range(0, 1)]
    [SerializeField]
    private float gravity;

    [SerializeField]
    private bool duble;

    private void Start()
    {
        stdspeed = speed;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed * 80, 0, 0);
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (!isGrounded)
        {
            rb.AddForce(Vector2.down * gravity * 100);
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

