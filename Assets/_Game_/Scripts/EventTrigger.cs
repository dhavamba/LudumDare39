using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour {

    //public typesOfEvents typeOfEvent;
    public EventManager manager;
    public GameObject objectToActivate;
    
    public enum TypesOfEvent
    {
        Porta, Stampa
    };

    public TypesOfEvent evento;

    bool isOnTrigger = false;
    bool isPressed = false;

    float timer = .5f;
    float timeToRemaing;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
    }

    void FixedUpdate()
    {
        if(timeToRemaing<=0)
        {
            isPressed = false;
        }
        if(!isPressed && isOnTrigger && Input.GetKeyDown(KeyCode.E))
        {
            manager.runEvent(evento.ToString(), objectToActivate);
            isPressed = true;
            timeToRemaing = timer;
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
        }
    }

}
