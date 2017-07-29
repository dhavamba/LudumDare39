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

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            manager.runEvent(evento.ToString(), objectToActivate);
        }
    }
}
