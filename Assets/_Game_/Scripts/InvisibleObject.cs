using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleObject : MonoBehaviour, IEvent
{

    public void Active()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Disactive()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }

}
