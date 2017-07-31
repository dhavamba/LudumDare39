using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
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
    [SerializeField]
    [Range(0, 1)]
    private float timeInvincible;


    private float speed;
    private bool isGrounded;
    private bool stunned,slowed,invincibile;

    private float timer,timerI;

    private float gravity;
    private Rigidbody2D rb;

    [Range(0, 1)] [SerializeField]
    private float jumpForce;

    private AudioSource aSrc;

    private Animator anim;

    public AudioClip passi, jetpack, mud;

    private void Awake()
    {
        speed = stdspeed;
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
        timer = timeStunned * 10;
        aSrc = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        timerI = timeInvincible * 3;
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
            if (GetInputJump())
            {
                aSrc.Stop();
                rb.gravityScale = gravityUp;
                Jump();
            }
            /*
            if (Input.GetAxis("Vertical") > 0)
            {
            }
            */
        }
    }

    private void FixedUpdate()
    {
        if (!stunned)
        {
            Movement();
            if (!isGrounded)
            {
                if (rb.velocity.y < 0)
                {
                    if (!aSrc.isPlaying)
                    {
                        aSrc.clip = jetpack;
                        aSrc.Play();
                    }
                    anim.SetBool("Caduta", true);
                    anim.SetBool("Salto", false);
                    anim.SetBool("Walk", false);
                    rb.gravityScale = gravityDw;
                }
            }
        }
        else
        {
            if (invincibile)
            {
                timerI -= Time.fixedDeltaTime;
                if (timerI <= 0)
                {
                    invincibile = false;
                }
            }
            Vector2 sp = new Vector2(0, rb.velocity.y);
            rb.velocity = sp;
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                stunned = false;
                timer = timeStunned * 10;
                anim.SetBool("Stun", false);
                invincibile = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GND" || collision.gameObject.tag == "MovingPlatform")
        {
            isGrounded = true;
        }

        if(collision.gameObject.tag == "MovingPlatform")
        {
            if(transform.position.y > collision.transform.position.y + 1)
            {
                transform.parent = collision.transform.GetChild(0).transform;
            }
            /*var emptyObject = new GameObject();
            emptyObject.transform.parent = collision.transform;
            transform.parent = emptyObject.transform;*/
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GND" || collision.gameObject.tag == "MovingPlatform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GND" || collision.gameObject.tag == "MovingPlatform")
        {
            isGrounded = false;
        }

        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    private float GetInputMovement()
    {
        return InputComand.Instance<InputComand>().Movement();
        //return Input.GetAxis("Horizontal");
    }

    void Movement()
    {
       
        float input = GetInputMovement();
        if (isGrounded && input != 0 && !aSrc.isPlaying)
        {

            anim.SetBool("Caduta", false);
            anim.SetBool("Salto", false);
            anim.SetBool("Walk", true);
            if (!slowed)
                aSrc.clip = passi;
            else
                aSrc.clip = mud;
            aSrc.Play();
        }
        if(isGrounded && input == 0)
        {
            anim.SetBool("Caduta", false);
            anim.SetBool("Salto", false);
            anim.SetBool("Walk", false);
        }
        Vector2 velocity = new Vector2(Vector2.right.x * speed * input * Time.fixedDeltaTime * 300, rb.velocity.y);

        rb.velocity = velocity;

        if (velocity.x < 0)
        {
            rb.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(velocity.x > 0)
        {
            rb.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    void Jump()
    {
        if (!stunned)
        {
            
            anim.SetBool("Caduta", false);
            anim.SetBool("Salto", true);
            anim.SetBool("Walk", false);
            rb.AddForce(Vector2.up * jumpForce * 1000);
        }
    }

    public void Slow()
    {
        if (!invincibile)
        {
            speed = stdspeed / 2;
            aSrc.Stop();
            slowed = true;
        }
    }

    public void Stun()
    {
        anim.SetBool("Stun", true);
        stunned = true;
    }

    public void ResetSpeed()
    {
        aSrc.Stop();
        slowed = false;
        speed = stdspeed;
    }
}