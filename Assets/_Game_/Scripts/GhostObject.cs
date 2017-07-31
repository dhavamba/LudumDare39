using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostObject : MonoBehaviour {

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
        timer = time;
    }

    void Update()
    {
        if (!withTrigger)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (isActive)
                {
                    Deactive();
                }
                else
                {
                    Active();
                }
                isActive = !isActive;
                timer = time * 10;
            }

        }
    }

    public void Use()
    {
        if(isActive)
        {
            Active();
        }
        else
        {
            Deactive();
        }
        isActive = !isActive;
    }

    public void Active()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    public void Deactive()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}
