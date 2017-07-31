using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(AudioSource))]

public class ObstacolManager : MonoBehaviour {

    AudioSource aSrc;

    public enum typeOfObstacles
    {
        Slow,Stun
    };

    public typeOfObstacles type;

    private void Awake()
    {
        aSrc = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (type)
            {
                case typeOfObstacles.Slow:
                    collision.gameObject.GetComponent<CharController>().Slow();
                    break;

                
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            switch(type)
            {
                case typeOfObstacles.Stun:
                    aSrc.Play();
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
    
}
