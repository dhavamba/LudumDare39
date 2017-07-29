using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]

public class ObstacolManager : MonoBehaviour {

    public string type;

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
    
}
