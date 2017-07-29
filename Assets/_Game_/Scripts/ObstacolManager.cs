using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]

public class ObstacolManager : MonoBehaviour {

    public string Tag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "")
        {

        }
    }

}
