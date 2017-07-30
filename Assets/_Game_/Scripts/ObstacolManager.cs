using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]

public class ObstacolManager : MonoBehaviour {

    public enum typeOfObstacles
    {
        Slow,Stun
    };

    public typeOfObstacles type;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (type)
            {
                case typeOfObstacles.Slow:
                    collision.gameObject.GetComponent<CharController>().Slow();
                    break;

                case typeOfObstacles.Stun:
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
