using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour {

    //public typesOfEvents typeOfEvent;
    EventManager manager;
    public GameObject objectToActivate;
    public bool interagibile = false;

    public enum TypesOfEvent
    {
        Porta, OggettoFantasma
    };

    public TypesOfEvent evento;

    bool isOnTrigger = false;
    bool isPressed = false;
    bool isActivated = false;
    

    float timer = .5f;
    float timeToRemaing;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
    }

    bool GetInputUse()
    {
        return InputComand.Instance<InputComand>().Use();
    }

    void FixedUpdate()
    {
        if(timeToRemaing<=0)
        {
            isPressed = false;
        }
        Debug.Log(GetInputUse());

        if(!isPressed && isOnTrigger && GetInputUse() && interagibile)
        {
            manager.runEvent(evento.ToString(), objectToActivate);
            isPressed = true;
            timeToRemaing = timer;
        }

        if(!interagibile && isOnTrigger && !isActivated)
        {
            manager.runEvent(evento.ToString(), objectToActivate);
            isActivated = true;
        }

        timeToRemaing -= Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isOnTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOnTrigger = false;
            isActivated = false;
        }
    }

}
