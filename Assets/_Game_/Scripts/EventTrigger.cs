using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    [SerializeField]
    private bool state;
    [SerializeField]
    private GameObject[] events;

    private bool isOnTrigger;

    private void Update()
    {
        if (isOnTrigger && GetInputUse())
        {
            foreach (GameObject obj in events)
            {
                if (!state)
                {
                    obj.GetComponent<IEvent>().Active();
                }
                else
                {
                    obj.GetComponent<IEvent>().Disactive();
                }
            }

            if (!state)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.blue;
            }

            state = !state;
        }

    }

    bool GetInputUse()
    {
        return Input.GetButtonDown("Use");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOnTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOnTrigger = false;
        }
    }

}
