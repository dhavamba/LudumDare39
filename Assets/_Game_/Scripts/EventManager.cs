using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
    
	public void runEvent(string type, GameObject activeObject)
    {
        switch (type)
        {
            case "Stampa":
                Print();
                break;
            case "Porta":
                Door(activeObject.GetComponent<Door>());
                break;
            case "OggettoFantasma":
                GhostObject(activeObject.GetComponent<GhostObject>());
                break;

        }

    }

    public void Print()
    {
        Debug.Log("Ho attivato l'evento");
    }

    public void Door(Door activeDoor)
    {
        activeDoor.Use();
    }

    public void GhostObject(GhostObject activeGhostObj)
    {
        activeGhostObj.Use();
    }
}
