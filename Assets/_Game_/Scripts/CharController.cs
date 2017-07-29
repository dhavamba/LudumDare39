using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]


public class CharController : MonoBehaviour {

    public float Speed;
    public bool IsGrounded,Duble;
    Rigidbody2D rb;
    public float JumpForce;
    public float Gravity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * Speed ,0,0);
        if(IsGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if(!IsGrounded)
        {
            rb.AddForce(Vector2.down * Gravity);
            if(Input.GetKeyDown(KeyCode.UpArrow) && Duble)
            {
                Duble = false;
                DubleJump();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "GND")
        {
            IsGrounded = true;
            Duble = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GND")
        {
            IsGrounded = false;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce);
    }

    void DubleJump()
    {
        Duble = false;
        Jump();
    }
}
