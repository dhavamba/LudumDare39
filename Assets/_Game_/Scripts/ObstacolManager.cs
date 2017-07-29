using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]

public class ObstacolManager : MonoBehaviour {

    public string type;
    public float timer, maxTime;
    public float speed;
    bool positive;

    private void Start()
    {
        timer = maxTime;

    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && positive)
        {
            timer = maxTime;
            positive = false;
        }
        else if (timer <= 0 && !positive)
        {
            positive = true;
            timer = maxTime;
        }

        switch (type)
        {
            case "VPlatform":
                VerticalMove();
                break;

            case "HPlatform":
                HorizontalMove();
                break;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (type)
            {
                case "Slow":
                    collision.gameObject.GetComponent<CharController>().Slow();
                    break;

                case "Stun":
                    collision.gameObject.GetComponent<CharController>().Stun();
                    break;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharController>().ResetSpeed();
        }
    }

    void VerticalMove()
    {
        if (positive)
            transform.Translate(new Vector2(0, speed));
        else
            transform.Translate(new Vector2(0,-speed));
    }

    void HorizontalMove()
    {
        if (positive)
            transform.Translate(new Vector2(speed,0));
        else
            transform.Translate(new Vector2(-speed,0));
    }
}
