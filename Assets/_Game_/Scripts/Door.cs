using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    bool isOpen;

	public void Use()
    {
        if(isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
        isOpen = !isOpen;
    }

    public void Open()
    {
        Debug.Log("Apro porta");
    }

    public void Close()
    {
        Debug.Log("Chiudo porta");
    }
}
