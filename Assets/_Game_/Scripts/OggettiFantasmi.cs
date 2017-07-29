using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OggettiFantasmi : MonoBehaviour {

    private bool isActive;
    [SerializeField]
    private bool withTrigger;

    [Range(0, 1)]
    [SerializeField]
    private float timer;
    [Range(0, 1)]
    [SerializeField]
    private float time;

    private void Start()
    {
        time *= 10;
    }

    void Update () {
        if (!withTrigger)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                if (isActive)
                {
                    Deactive();
                }
                else
                {
                    Active();
                }
            }

        }
	}

    public void Active()
    {
        isActive = true;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<PolygonCollider2D>().enabled = true;
    }

    public void Deactive()
    {
        isActive = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<PolygonCollider2D>().enabled = false;
    }
}
